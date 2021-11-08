﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Т08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> userInfo = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ").ToArray();

            while (input[0] != "End")
            {
                string company = input[0];
                string userID = input[1];

                if (!userInfo.ContainsKey(company))
                {
                    userInfo.Add(company, new List<string>());
                    userInfo[company].Add(userID);
                }
                else if(userInfo.ContainsKey(company))
                {
                    foreach (var compan in userInfo)
                    {
                        if (compan.Key == company)
                        {
                            if (!compan.Value.Contains(userID))
                            {
                                compan.Value.Add(userID);
                                break;
                            }
                        }
                    }
                }


                input = Console.ReadLine().Split(" -> ").ToArray();
            }

            userInfo = userInfo.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var companyName in userInfo)
            {
                Console.WriteLine(companyName.Key);
                for (int i = 0; i < companyName.Value.Count; i++)
                {
                    Console.WriteLine($"-- {companyName.Value[i]}");
                }
            }
        }
    }
}
