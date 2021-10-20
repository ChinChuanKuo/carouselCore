namespace carouselCore.Models
{
    public class CheckClass
    {
        public string checkfstitle(string title)
        {
            int lastIndex = title.LastIndexOf(" ");
            switch (lastIndex)
            {
                case -1:
                    return title;
            }
            return title.Substring(0, title.LastIndexOf(" "));
        }

        public string checksndtitle(string title)
        {
            int lastIndex = title.LastIndexOf(" ");
            switch (lastIndex)
            {
                case -1:
                    return "";
            }
            switch (title.Substring(lastIndex, title.Length - lastIndex).TrimEnd())
            {
                case "":
                    return "";
            }
            return title.Substring(lastIndex + 1, title.Length - lastIndex - 1);
        }

        public string checkvalues(string value)
        {
            switch (value.IndexOf('('))
            {
                case -1:
                    if (value.Length < 8)
                    {
                        return value;
                    }
                    return value.Substring(2, value.Length - 2).TrimEnd();
            }
            return value.Split("(")[0].Substring(2, value.Split("(")[0].Length - 2).TrimEnd() + " (" + value.Split("(")[1];
        }

        public string checktwovalues(string fstValue, string sndValue, string trdValue, string fthValue)
        {
            if (fstValue.Length < 8)
            {
                if (sndValue.Length < 8)
                {
                    if (trdValue.Length < 8)
                    {
                        return checkvalues(fthValue);
                    }
                    return checkvalues(trdValue);
                }
                return checkvalues(sndValue);
            }
            return checkvalues(fstValue);
        }

        public string checkNewObjects(string beforeValue, string afterValue)
        {
            switch (afterValue)
            {
                case "":
                    return beforeValue;
            }
            return afterValue;
        }
    }
}