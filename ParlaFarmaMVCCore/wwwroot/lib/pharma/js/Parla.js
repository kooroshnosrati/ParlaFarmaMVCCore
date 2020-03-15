function ScrollObjects(TagID, PageID, FromOwn) {
    try {
        var JumpTo = '#' + TagID;
        JumpTo = "div[data-id='" + TagID + "']";
        console.log(JumpTo);
        try {
            var offs = $(JumpTo).offset().top;
            var height = $(JumpTo).outerHeight();
        } catch (e) {
            ;
        }
        switch (TagID) {
            case 'SocialResponsibility':
                if (!FromOwn) {
                    height = Number(height) + 2002;
                    break;
                }
            case 'OurCulture':
                if (!FromOwn) {
                    height = Number(height) + 1241;
                    break;
                }
            case 'ParlaTeam':
                if (PageID == 'Index') {
                    height = Number(height) - 200;
                    break;
                }
                if (!FromOwn) {
                    height = Number(height) + 2883;
                    break;
                }
            case 'OurValues':
                if (!FromOwn) {
                    height = Number(height) + 342;
                    break;
                }
            case 'OurMission':
            case 'AboutParla':
            case 'Distributors':
            case 'ExportDevelopment':
            case 'Vacancies':
            case 'WhyPARLA':
                if (FromOwn) {
                    height = Number(height) - 110;
                }
                else {
                    height = Number(height) - 220;
                }
                break;
            default:
        }
        var sum = Number(offs) + Number(height);
        console.log('PageID:' + PageID + ' TagID:' + TagID + ' Sum :' + sum + ' Offset:' + offs + ' Height:' + height);
        $('html, body').animate({ scrollTop: sum + 'px' }, 'slow', 'easeInOutExpo');
    }
    catch (err) {
        //document.getElementById("demo").innerHTML = err.message;
        console.log(err.message);
    }
}
