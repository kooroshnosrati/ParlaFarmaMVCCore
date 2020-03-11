function ScrollObjects(TagID, ScrollAmount, PageID, URLRequested) {
    try {
        if (URLRequested) {
            console.log('URLRequested');
            var elmnt = document.getElementById(TagID);
            elmnt.scrollIntoView();
            console.log('URLRequested');
            return;
        }
        var JumpTo = '#' + TagID;
        try {
            var offs = $(JumpTo).offset().top;
            var height = $(JumpTo).height();
        } catch (e) {
            ;
        }
        switch (TagID) {
            case 'AboutParla':
                if (PageID == 'Index') {
                    location.replace("EN/Home/AboutUs?ScrollId=AboutParla&ScrollAmount=-100&URLRequested=true")
                }
                else if (PageID == 'AboutUs') {
                    height = Number(height) + Number(ScrollAmount);
                    break;
                }
            case 'ParlaTeam':
                if (PageID == 'Index') {
                    height = Number(height) - 200 + Number(ScrollAmount);
                }
                else if (PageID == 'AboutUs') {
                    console.log('ScrollAmount : ' + ScrollAmount + '--- PageID : ' + PageID + '--- TagID :' + TagID);
                    height = Number(height) + Number(ScrollAmount);
                }
                break;
            case 'OurCulture':
                if (PageID == 'Index') {
                    height = Number(height) - 200 + Number(ScrollAmount);
                }
                else if (PageID == 'AboutUs') {
                    height = Number(height) + Number(ScrollAmount);
                }
                break;
            case 'SocialResponsibility':
                if (PageID == 'Index') {
                    height = Number(height) - 200 + Number(ScrollAmount);
                }
                else if (PageID == 'AboutUs') {
                    height = Number(height) + Number(ScrollAmount);
                }
                break;
            case 'OurValues':
                if (PageID == 'Index') {
                    height = Number(height) - 110 + Number(ScrollAmount);
                } else if (PageID == 'AboutUs') {
                    height = Number(height) + Number(ScrollAmount);
                }
                break;
            case 'OurMission':
                if (PageID == 'Index') {
                    height = Number(height) - 50 + Number(ScrollAmount);
                } else if (PageID == 'AboutUs') {
                    height = Number(height) + Number(ScrollAmount);
                }
                break;
            case 'Vacancies':
                height = Number(height) - 220 + Number(ScrollAmount);
                break;
            case 'WhyPARLA':
                height = Number(height) - 220 + Number(ScrollAmount);
                break;
            default:
        }
        //height = $(window).innerHeight();
        var sum = Number(offs) + Number(height);
        console.log('Sum : ' + sum + ' Offset :' + offs + ' Height : ' + height + ' ScrollAmount :' + ScrollAmount);
        $('html, body').animate({ scrollTop: sum + 'px' }, 'slow');
    }
    catch (err) {
        //document.getElementById("demo").innerHTML = err.message;
        console.log(err.message);
    }
}
