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

        public ArrayList textData = new ArrayList();
        
        public Load(string path) : base(path){
            string currentLine = ReadLine();
            while(currentLine != null){
                textData.Add(currentLine);
                currentLine = ReadLine();
            }
        }

        // get data
        public int getElement(string category, string name, int defaultValue){
            string valueSpot = " " + category + " : " + name + " : ";
            string wantedLine = null;

            foreach(string line in textData){
                if(line.Contains(valueSpot)){
                    wantedLine = line;
                }
            }

            if(wantedLine != null){
                string dataString = wantedLine.Substring(valueSpot.Length - 1);
                return int.Parse(dataString);
            }
            
            return defaultValue;
        }

        public double getElement(string category, string name, double defaultValue){
            string valueSpot = " " + category + " : " + name + " : ";
            string wantedLine = null;

            foreach(string line in textData){
                if(line.Contains(valueSpot)){
                    wantedLine = line;
                }
            }

            if(wantedLine != null){
                string dataString = wantedLine.Substring(valueSpot.Length - 1);
                return double.Parse(dataString);
            }
            
            return defaultValue;
        }

        public string getElement(string category, string name, string defaultValue){
            string valueSpot = " " + category + " : " + name + " : ";
            string wantedLine = null;

            foreach(string line in textData){
                if(line.Contains(valueSpot)){
                    wantedLine = line;
                }
            }

            if(wantedLine != null){
                string dataString = wantedLine.Substring(valueSpot.Length - 1);
                return dataString;
            }
            
            return defaultValue;
        }

        public float getElement(string category, string name, float defaultValue){
            string valueSpot = " " + category + " : " + name + " : ";
            string wantedLine = null;

            foreach(string line in textData){
                if(line.Contains(valueSpot)){
                    wantedLine = line;
                }
            }

            if(wantedLine != null){
                string dataString = wantedLine.Substring(valueSpot.Length - 1);
                Debug.Log(dataString);
                return float.Parse(dataString);
            }
            
            return defaultValue;
        }
    }
}