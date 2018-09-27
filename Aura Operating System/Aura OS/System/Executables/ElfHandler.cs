﻿using CosmosELFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura_OS.System.Executables
{
	public unsafe class ElfHandler
	{
		private static byte[] UnmanagedString(string s)
		{
			var re = new byte[s.Length + 1];

			for (int i = 0; i < s.Length; i++)
			{
				re[i] = (byte)s[i];
			}

			re[s.Length + 1] = 0; //c requires null terminated string
			return re;
		}

		//this is suppose to be in before run, will need it own command
		public static void Run(byte[] file)
		{
			fixed (byte* ptr = file)
			{
				var exe = new UnmanagedExecutible(ptr);
				exe.Load();
				exe.Link();

				new ArgumentWriter();
				exe.Invoke("start");

                //
                //new ArgumentWriter()
                //	.Push(5)  //fg
                //	.Push(15); //bg
                //exe.Invoke("tty_set_color");
                //
                //fixed (byte* str = UnmanagedString("Hello World"))
                //{
                //	new ArgumentWriter()
                //		.Push((uint)str);
                //	exe.Invoke("tty_puts");
                //}


            }
		}
	}
}
