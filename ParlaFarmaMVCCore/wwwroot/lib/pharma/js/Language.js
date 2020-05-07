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

//function GetLangDictionary() {
//    return 'salam';
//}