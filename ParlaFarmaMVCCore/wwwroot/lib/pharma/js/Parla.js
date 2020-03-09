//function ScrollObjects(TagID, ScrollAmount, PageID) {
//    var elmnt = document.getElementById(TagID);
//    elmnt.scrollIntoView();
//}

function ScrollObjects(TagID, ScrollAmount, PageID) {
    //alert('ScrollAmount : ' + ScrollAmount + '--- PageID : ' + PageID + '--- TagID :' + TagID);
    try {
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
                    location.replace("EN/Home/AboutUs?ScrollId=AboutParla&ScrollAmount=-100")
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

            default:
        }
        //height = $(window).innerHeight();
        var sum = Number(offs) + Number(height);
        console.log('Sum : ' + sum + ' Offset :' + offs + ' Height : ' + height);
        $('html, body').animate({ scrollTop: sum + 'px' }, 'slow');
    }
    catch (err) {
        //document.getElementById("demo").innerHTML = err.message;
        alert(err.message);
    }
}
