using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ADO.Net_Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection connect = new SqlConnection(Config.ConnectionString);
            connect.Open();
            /* TASK 1
              
            string comm1 = @"SELECT Name, COUNT(*) AS cont FROM MinionsVillains mv
                                JOIN Villains v ON v.Id = mv.VillainId
                                GROUP BY Name
                                HAVING COUNT(*) > 3
                                ORDER BY COUNT(*) DESC";
            SqlCommand cmd1 = new SqlCommand(comm1,connect);
            using SqlDataReader reader = cmd1.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["cont"]}");
            }
            reader.Dispose();

            TASK 2

            string comm2 = @"SELECT Name FROM Villains WHERE Id = @Id";
            string comm3 = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
            SqlCommand cmd2 = new SqlCommand(comm2,connect);
            SqlCommand cmd3 = new SqlCommand(comm3,connect);
            int par = int.Parse(Console.ReadLine());
            cmd2.Parameters.AddWithValue("@Id", par);
            cmd3.Parameters.AddWithValue("@Id", par);
            object villain = cmd2.ExecuteScalar();
            if (villain == null) Console.WriteLine($"No villain with ID {par} exists in the database.");
            else
            {
                Console.WriteLine($"Villain: {villain}");
                using SqlDataReader reader = cmd3.ExecuteReader();
                if (!reader.HasRows) { Console.WriteLine("(no minions)"); return; }
                while (reader.Read()) Console.WriteLine($"{reader["RowNum"]}. " +
                    $"{reader["Name"]} " +
                    $"{reader["Age"]}");
                reader.Dispose();
            }
            
            TASK 3

            string[] minionInf = Console.ReadLine().Split(new char[] { ':', ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionInf[1];
            int minionAge = int.Parse(minionInf[2]);
            string minionTown = minionInf[3];
            string[] VillainInf = Console.ReadLine().Split(new char[] { ':', ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            string villainName = VillainInf[1];
            string townCheck = @"SELECT Id FROM Towns WHERE Name = @Name";
            SqlCommand cmdTown = new SqlCommand(townCheck, connect);
            cmdTown.Parameters.AddWithValue("@Name", minionTown);
            object town = cmdTown.ExecuteScalar();
            if (town == null)
            {
                SqlCommand cmdInsertTown = new SqlCommand(@"INSERT INTO Towns (Name) VALUES (@townName)", connect);
                cmdInsertTown.Parameters.AddWithValue("@townName", minionTown);
                cmdInsertTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
            int townId = (int)cmdTown.ExecuteScalar();
            string villainCheck = @"SELECT Id FROM Villains WHERE Name = @Name";
            SqlCommand cmdVillain = new SqlCommand(villainCheck, connect);
            cmdVillain.Parameters.AddWithValue(@"@Name", villainName);
            object villain = cmdVillain.ExecuteScalar();
            if (villain == null)
            {
                SqlCommand cmdInsertVillain = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@villainName, 4)", connect);
                cmdInsertVillain.Parameters.AddWithValue("@villainName", villainName);
                cmdInsertVillain.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            int villainId = (int)cmdVillain.ExecuteScalar();
            SqlCommand minionId = new SqlCommand(@"SELECT COUNT(*) FROM Minions", connect);
            int minId = (int)minionId.ExecuteScalar();
            string addMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)
                                 INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
            SqlCommand cmdAddMinion = new SqlCommand(addMinion, connect);
            cmdAddMinion.Parameters.AddWithValue("@name", minionName);
            cmdAddMinion.Parameters.AddWithValue("@age", minionAge);
            cmdAddMinion.Parameters.AddWithValue("@townId", townId);
            cmdAddMinion.Parameters.AddWithValue("@villainId", villainId);
            cmdAddMinion.Parameters.AddWithValue("@MinionId", minId+1);
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            
            TASK 4
          
            string country = Console.ReadLine();
            string townList = @"UPDATE Towns
                                   SET Name = UPPER(Name)
                                 WHERE CountryCode = 
                                        (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            SqlCommand cmdTownList = new SqlCommand(townList, connect);
            cmdTownList.Parameters.AddWithValue("@countryName", country); 
            cmdTownList.ExecuteNonQuery();
            string result = @"SELECT t.Name 
                               FROM Towns as t
                               JOIN Countries AS c ON c.Id = t.CountryCode
                              WHERE c.Name = @countryName";
            SqlCommand cmdTownList1 = new SqlCommand(result, connect);
            cmdTownList1.Parameters.AddWithValue("@countryName", country);
            SqlDataReader reader = cmdTownList1.ExecuteReader();
            int i = 0;
            while (reader.Read()) i++;
            reader.Close();
            Console.WriteLine($"{i} town names were affected.");
            reader = cmdTownList1.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read()) list.Add((string)reader["Name"]);
            Console.WriteLine($"[{string.Join(", ", list)}]");
            reader.Close();

            TASK 5
            
            int id = int.Parse(Console.ReadLine());
            SqlTransaction trans = connect.BeginTransaction();
            try
            {
                string villainName = @"SELECT Name FROM Villains WHERE Id = @villainId";
                SqlCommand cmdName = new SqlCommand(villainName, connect, trans);
                cmdName.Parameters.AddWithValue("@villainId", id);
                villainName = (string)cmdName.ExecuteScalar();
                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    Environment.Exit(1);
                }
                string removeStuff = @"DELETE FROM MinionsVillains 
                                          WHERE VillainId = @villainId
                                    
                                    DELETE FROM Villains
                                          WHERE Id = @villainId";
                SqlCommand cmdDeletion = new SqlCommand(removeStuff, connect, trans);
                cmdDeletion.Parameters.AddWithValue("@villainId", id);
                villainName = (string)cmdName.ExecuteScalar();
                string minionsToFree = @"SELECT COUNT(*) FROM MinionsVillains
                                            Where VillainId = @villainId";
                SqlCommand cmdFree = new SqlCommand(minionsToFree, connect, trans);
                cmdFree.Parameters.AddWithValue("@villainId", id);
                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{(int)cmdFree.ExecuteScalar()} minions were released.");
                cmdDeletion.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                trans.Rollback();
                return;
            }

            TASK 6
            
            SqlCommand cmd = new SqlCommand(@"SELECT Name FROM Minions",connect);
            using SqlDataReader reader = cmd.ExecuteReader();
            List<string> names = new List<string>();
            while (reader.Read()) names.Add((string)reader["Name"]);
            bool fi = false;
            int y = names.Count-1;
            for (int i = 0; names.Count>0;)
            {
                if (!fi)
                {
                    Console.WriteLine(names[i]);
                    names.RemoveAt(i);
                    y--;
                    fi = true;
                }
                else
                {
                    Console.WriteLine(names[y]);
                    names.RemoveAt(y);
                    y--;
                    fi = false;
                }
            }
            reader.Close();

            TASK 7
            
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string updation = @"UPDATE Minions
                                   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                 WHERE Id = @Id";
            SqlCommand cmdUpdateAge = new SqlCommand(updation, connect); 
            cmdUpdateAge.Parameters.AddWithValue("@Id", minionIds[0]);
            cmdUpdateAge.ExecuteNonQuery();
            for (int i = 1; i < minionIds.Length; i++)
            {
                cmdUpdateAge.Parameters.Clear();
                cmdUpdateAge.Parameters.AddWithValue("@Id", minionIds[i]);
                cmdUpdateAge.ExecuteNonQuery();
            }
            SqlCommand cmdNamesAges = new SqlCommand(@"SELECT Name, Age FROM Minions", connect);
            using SqlDataReader reader = cmdNamesAges.ExecuteReader();
            while (reader.Read()) Console.WriteLine($"{(string)reader["Name"]} {(int)reader["Age"]}");
            reader.Close();

            TASK 8
            */
            SqlCommand cmdExecProc = new SqlCommand(@"EXEC usp_GetOlder @Id", connect);
            cmdExecProc.Parameters.AddWithValue("Id", int.Parse(Console.ReadLine()));
            using SqlDataReader reader = cmdExecProc.ExecuteReader();
            while (reader.Read()) Console.WriteLine($"{(string)reader["Name"]} - {(int)reader["Age"]} years old");
            reader.Close();
            connect.Close();
        }
    }
}
