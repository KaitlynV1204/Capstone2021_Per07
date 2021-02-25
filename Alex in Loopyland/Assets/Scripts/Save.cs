using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/*
Description: This save system saves things into category. Lets say you have the weapon category.
You would save it in a weapon -> sword ->[NAME FILE IN GAME/ number]
I made it similar to gamemaker system in the link below
https://docs.yoyogames.com/source/dadiospice/002_reference/file%20handling/ini%20files/ini_open.html


This inherits the StreamWriter, so its based off a official code and i tweaked to make it fit.
here is the docs on how to use that code. Sames goes for StreamReader

StreamWriter (writing data)
https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-5.0

StreamReader (reading data)
https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=net-5.0


basically just follow above on how to save data, but the part i change it up a bit, allows you
to save stuff in category

EXAMPLE:
StreamWriter input = new StreamWriter("/documents/file.txt");    // gets that file
int some_number = input.readline(); // reads the first line in the file that has an integer value
// Not entirely accurate (hopefully yes), but the main jist is here

-peace, arath
*/

namespace Capstone 
{
    public class Save : StreamWriter{

        public Save(string path) : base(path) {
            
        }

        // Set data
        public void setElement(string category, string name, int value){
            string valueSpot = " " + category + " : " + name + " : ";
            WriteLine(valueSpot + value);
        }

        public void setElement(string category, string name, double value){
            string valueSpot = " " + category + " : " + name + " : ";
            WriteLine(valueSpot + value);
        }

        public void setElement(string category, string name, string value){
            string valueSpot = " " + category + " : " + name + " : ";
            WriteLine(valueSpot + value);
        }

        public void setElement(string category, string name, float value){
            string valueSpot = " " + category + " : " + name + " : ";
            WriteLine(valueSpot + value);
        }

        public void organize(){
            // TODO organiz file if mixed intentially 
        }
    }

    public class Load : StreamReader{

        public Load(string path) : base(path){
            StreamReader f = new StreamReader("fsdf");
               
        }

        // get data
        public void getElement(string category, string name, int defaultValue){
            string valueSpot = " " + category + " : " + name + " : ";
            int data = defaultValue;
            
            string currentLine = ReadLine();
            string wantedLine;
            while(currentLine != null){
                if(currentLine.Contains(valueSpot)){
                    wantedLine = currentLine;
                }
            }
            BaseStream = 0;

            if(wantedLine != null){
                // convert string to int later TODO
                data = wantedLine.Substring(valueSpot.Length() -1);
            }

            return data;
        }

        public void getElement(string category, string name, double value){
            ReadLine();
        }

        public void getElement(string category, string name, string value){
            string valueSpot = " " + category + " : " + name + " : ";
            ReadLine(valueSpot + value);
        }

        public void getElement(string category, string name, float value){
            string valueSpot = " " + category + " : " + name + " : ";
            ReadLine(valueSpot + value);
        }
    }
}