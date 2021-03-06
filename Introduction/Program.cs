﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***");
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path) {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;

            //var query = new DirectoryInfo(path).GetFiles()
            //    .OrderByDescending(f => f.Length)
            //    .Take(5);

            foreach (var file in query.Take(5)) {
                Console.WriteLine($"{file.Name,-25} : {file.Length,20:NO}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path) {
            DirectoryInfo directory = new DirectoryInfo(path);
            var files = directory.GetFiles();
            Array.Sort(files,new FileInfoComparer());

            foreach (var file in files) {
                Console.WriteLine($"{file.Name, -25} : {file.Length, 20:NO}");
            }
        }
    }
    public class FileInfoComparer : IComparer<FileInfo> {
        public int Compare(FileInfo x, FileInfo y) {
            return y.Length.CompareTo(x.Length);
        }
    }
}
