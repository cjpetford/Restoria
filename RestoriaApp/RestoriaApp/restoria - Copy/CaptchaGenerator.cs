using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppRestoria
{
    public class CaptchaGenerator
    {
        private Random random;

        public string Captcha { get { return Captcha; } }

        public CaptchaGenerator()
        {
            random = new Random();
        }

        public string GenerateCaptcha(int length)
        {
            string Captcha = "";
            int capx = 0;

            do
            {
                int gen = random.Next(48, 123);
                if ((gen >= 48 && gen <= 57) || (gen >= 65 && gen <= 90) || (gen >= 97 && gen <= 122))
                {
                    Captcha += (char)gen;
                    capx++;
                    if (capx == length)
                        break;
                }
            }
            while (true);

            return Captcha;
        }

        //validating the captcha
        public bool ValidateCaptcha(string inputCaptcha)
        {
            return string.Equals(inputCaptcha, Captcha, StringComparison.OrdinalIgnoreCase);
        }
    }
}

