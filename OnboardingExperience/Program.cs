using System;using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace OnboardingExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            SpeakAndWrite("Welcome to our Onboarding Experience");

            user.FirstName = AskQuestion("What is your first name?");
            SpeakAndWrite("Hi " + user.FirstName);

            user.LastName = AskQuestion("What is your last name?");
            SpeakAndWrite("Great! " + user.FullName);

            user.IsAccountOwner = AskBoolQuestion("Are you the account owner?");
            SpeakAndWrite("Perfect, " + user.FirstName);

            user.AType = AType("What is your Account Type?");
            SpeakAndWrite("Great, I got " + user.AType);

            user.AccountNumber = AskIntQuestion("What is your account number?");
            SpeakAndWrite("Great, now let's set up your pin!");

            user.AccountPin = AskAccountPin("What would you like your pin to be?", 4);
            SpeakAndWrite("Perfect, you chose" + " " + user.AccountPin);

            user.EmailAddress = AskQuestion("One last thing, what is your email address?");
            SpeakAndWrite("Woohoo, I got " + " " + user.EmailAddress);

            SpeakAndWrite("You've completed the Onboarding Experience, THANK YOU!");
            Console.ReadLine();


        }

        
            
        
        static string AskQuestion(string question)
        {
            SpeakAndWrite(question);
            return Console.ReadLine();
        }

        private static void SpeakAndWrite(string stringtoSpeak)
        {
            Console.WriteLine(stringtoSpeak);
            var syn = new SpeechSynthesizer();
            syn.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Child);
            syn.Speak(stringtoSpeak);

        }
        static bool AskBoolQuestion(string question)
        {
            var hasAnswered = false;
            var responseBool = false;

            while (!hasAnswered)
            {
                var response = AskQuestion(question + " (yes/no)");

                if (response == "yes")
                {
                    responseBool = true;
                    hasAnswered = true;
                }
                else if (response == "no")
                {
                    responseBool = false;
                    hasAnswered = true;
                }
            }

            return responseBool;
        }
        /// <summary>
        /// the purpose of this method is to ask an int question
        /// </summary>
        /// <param name="question">question to be asked by the console.</param>
        /// <returns></returns>
        static int AskIntQuestion(string question)
        {
            int? number = null;
            while (number == null)
            {
                var response = AskQuestion(question);
                if (Int32.TryParse(response, out int possibleResponse))
                {
                    number = possibleResponse;
                }
            }

            return (int) number;
        }

        static string AskAccountPin(string question, int length)
        {
            string numberString = null;

            while (numberString == null)
            {
                var response = AskQuestion(question);
                if (response.Length == length && Int32.TryParse(response, out int possiblereturn))
                {
                    numberString = response;
                }
            }
            return numberString;
            
        }

        static AccountType AType(string question)
        {
            AccountType? aType = null;

            while (aType == null)
            {
                var response = AskQuestion(question);

                if (Enum.TryParse(response, out AccountType actualType))
                {
                    aType = actualType;
                }
            }
            
            return (AccountType)aType;
        }
    }

}
