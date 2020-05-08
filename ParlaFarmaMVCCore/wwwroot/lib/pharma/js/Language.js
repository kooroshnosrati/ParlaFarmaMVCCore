function ChangeLanguage(curLang, newLang) {
    //alert(window.location.search);
    var searchStr = window.location.search;
    if (searchStr.indexOf("lang=") == -1) {
        searchStr += 'lang=' + newLang;
    }
    else {
        searchStr = searchStr.replace('lang=' + curLang, 'lang=' + newLang);
    }
    //alert(locStr);
    window.location.search = searchStr;
}

function navigateMe(pathStr, hashStr) {
    //alert('Location : ' + window.location +
    //    '\n ancestorOrigins :' + window.location.ancestorOrigins +
    //    '\n hash :' + window.location.hash +
    //    '\n host :' + window.location.host +
    //    '\n hostname :' + window.location.hostname +
    //    '\n href :' + window.location.href +
    //    '\n origin :' + window.location.origin +
    //    '\n pathname :' + window.location.pathname +
    //    '\n port :' + window.location.port +
    //    '\n protocol :' + window.location.protocol +
    //    '\n search :' + window.location.search 
    //);
    if (hashStr != null) {
        window.location.hash = hashStr;
    }
    window.location.pathname = pathStr;
}


//function GetLangDictionary() {
//    return 'salam';
//}