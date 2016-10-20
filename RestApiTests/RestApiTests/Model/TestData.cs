using System.Collections.Generic;

namespace RestApiTests.Model
{
    class TestData
    {
        private string baseurl = "http://kn-ktapp.herokuapp.com/";

        public string BaseUrl
        {
            get
            {
                return baseurl;
            }
        }

        public dynamic GetResourcePath()
        {
            var uri = new Dictionary<string, object>
            {
                {"correctAccountsPath", "apitest/accounts" },
                {"correctSingleAccountsPath", "apitest/accounts/12345679" },
                {"correctPathWithQuery", "apitest/accounts/12345678/?rename=name"}, //200 OK
                {"Path?1", "?apitest/accounts/12345678"}, //200 OK Error
                {"Path?2", "apitest/accounts/12345678?"}, //200 OK Completed
                {"emptyPath", string.Empty}, //200 OK Error
                {"PathЪ", "apitest/accounts/Ъ"}, //500
                {"Path[", "apitest/accounts/12345678["}, //500
                {"Path/[", "apitest/accounts/12345678/["}, //405               
                {"Path?3", "apitest?/accounts/12345678"}, //404
                {"Path&", "&apitest/accounts/12345678"}, //404

                {"correctPostPath", "apitest/accounts/12345678/rename"}, //200
                {"correctPostPath/?", "apitest/accounts/12345678/rename/?rename=name"}, //200
                {"incorrectPostPath[", "apitest/accounts/12345678/rename["}, //400
                {"incorrectPostPath?", "apitest/accounts/12345678/?rename"}, //405
                {"incorrectPostPath&", "apitest/accounts/12345678/rename&"}, //404
                {"incorrectPostPath/[", "apitest/accounts/12345678/rename/["}, //500
                {"incorrectPostPath/&", "apitest/accounts/12345678/rename/&"}, //404
            };
            return uri;
        }

        public dynamic GetValue()
        {
            var values = new Dictionary<string, object>
            {
                {"emptyValue", string.Empty},
                {"correctValue", "1234567890ЙЦУКЕНГШЩЗФЫВАПРОЛДЖЭЯЧСМИТЬБЮQWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()_+{}[]<>?;:'"},
                {"doubleMax", 1.7976931348623157E+308D },
                {"doubleMin", -1.7976931348623157E+308D },
                {"doubleValue", 4.94065645841247E+7D },
                {"zeroHex", 0x0000000000000000},
                {"uint64MaxValueHex", 0xffffffffffffffff},
                {"secondAccount",12345679},
                {"secondPan","5449***1332" }
            };
            return values;
        }

        public dynamic GetKey()
        {
            var key = new Dictionary<string, object>
            {
                {"correctKey", "name"},
                {"emptyKey", string.Empty},
                {"singleSpaceKey", " "},
            };
            return key;
        }
    }
}
