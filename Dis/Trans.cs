using System;
using System.Collections.Generic;
using System.Text;
using YandexLinguistics.NET;

namespace Dis
{
    class Trans
    {
        YandexLinguistics.NET.Translator Tr;
        const string KeyApi = "trnsl.1.1.20200419T103036Z.e3881bfa83378f1c.2c14e74712678836376957b0f8500c4fdcbc7425";

        public string BTranslator(string wordToTranslate, LangPair langPair)
        {
            Tr = new YandexLinguistics.NET.Translator(KeyApi);
            return Tr.Translate(wordToTranslate, langPair).Text;
        }
        public LangPair GetLangPair(string inputLang, string outputLang)
        {
            LangPair lp = new LangPair();



            switch (inputLang)
            {

                case "en":

                    lp.InputLang = Lang.En;

                    break;

                case "ru":

                    lp.InputLang = Lang.Ru;

                    break;
            }

            switch (outputLang)
            {
                
                case "en":

                    lp.OutputLang = Lang.En;

                    break;
                
                case "ru":

                    lp.OutputLang = Lang.Ru;

                    break;
            }
            return lp;
            
        }
        //public string Translator(string wordToTranslate, LangPair langPair)
        //{
         //   return Tr.Translate(wordToTranslate, langPair).Text;
        //}
    }
}

