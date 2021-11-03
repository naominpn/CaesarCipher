using System;
using System.Collections.Generic;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {

            RunProgram();
        }

        static void RunProgram()
        {
            Console.WriteLine("Would you like to encrypt or decrypt? ENCRYPT/DECRYPT");
            string userChoice = Console.ReadLine();

            if (userChoice.ToLower() == "encrypt")
            {
                Console.WriteLine("Enter message to encrypt: ");
                //The app doesn’t work with uppercase letters. Fix that by converting any message to lowercase.
                string userMessage = Console.ReadLine().ToLower();
                char[] secretMessage = userMessage.ToCharArray();
                Console.WriteLine("Enter a number key: ");
                string userInput = Console.ReadLine();
                bool success = int.TryParse(userInput, out int key);

                if (success)
                {
                    Encrypt(secretMessage, key);
                }
                else
                {
                    Console.WriteLine($"\"{userInput}\" is not a number \nTry again \n...\n\n");
                    RunProgram();
                }


            }
            else if (userChoice.ToLower() == "decrypt")
            {
                Console.WriteLine("Enter message to decrypt: ");
                string userMessage = Console.ReadLine().ToLower();
                char[] secretMessage = userMessage.ToCharArray();
                Console.WriteLine("Enter a number key: ");
                string userInput = Console.ReadLine();

                bool success = int.TryParse(userInput, out int key);

                if (success)
                {
                    Decrypt(secretMessage, key);
                }
                else
                {
                    Console.WriteLine($"\"{userInput}\" is not a number \nTry again \n...\n\n");
                    RunProgram();
                }

            }
            else
            {
                Console.WriteLine("Error, try again \n\n");
                RunProgram();
            }
        }

        //Rewrite the loop as a method Encrypt() which takes a character array and key and returns an encrypted character array.
        static void Encrypt(char[] message, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] encryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                char aChar = message[i];

                //The app doesn’t work with symbols, like !or?.Skip any symbols in your loop so that they are not encrypted.
                if (aChar == '!' || aChar == '?')
                {
                    continue;
                }
                int charPos = Array.IndexOf(alphabet, aChar);
                int newCharPos = (charPos + key) % 26;
                encryptedMessage[i] = alphabet[newCharPos];
            }

            string newMessage = String.Join("", encryptedMessage);
            Console.WriteLine(newMessage);
        }

        static void Decrypt(char[] message, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] reverseAlphabet = new char[alphabet.Length];
            char[] decryptedMessage = new char[message.Length];
            int reverseIndex = 0;

            //Creating reverse alphabet array
            for (int i = alphabet.Length - 1; i >= 0; i--)
            {
                reverseAlphabet[reverseIndex] = alphabet[i];
                reverseIndex++;
            }


            for (int i = 0; i < message.Length; i++)
            {
                char aChar = message[i];
                int charPos = Array.IndexOf(alphabet, aChar);
                int newCharPos = charPos - key;
                if (newCharPos < 0)
                {
                    decryptedMessage[i] = reverseAlphabet[Math.Abs(newCharPos) - 1];
                }
                else
                {
                    decryptedMessage[i] = alphabet[newCharPos];
                }

            }
            string oldMessage = String.Join("", decryptedMessage);
            Console.WriteLine(oldMessage);

        }

    }
}
