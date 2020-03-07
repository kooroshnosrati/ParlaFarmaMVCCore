
function ScrollObjects(TagID, ScrollAmount) {
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
                    location.replace("EN/Home/AboutUs?ScrollId=AboutParla&ScrollAmount=150")
                }
                else if (PageID == 'AboutUs') {
                    height = Number(height) - 200 - Number(ScrollAmount);
                    break;
                }
            case 'ParlaTeam':
                height = Number(height) - 200 - Number(ScrollAmount);
                break;
            case 'OurCulture':
                height = Number(height) - 200 - Number(ScrollAmount);
                break;
            case 'SocialResponsibility':
                height = Number(height) - 200 - Number(ScrollAmount);
                break;
            case 'OurValues':
                if (PageID == 'Index') {
                    height = Number(height) - 110 - Number(ScrollAmount);
                } else if (PageID == 'AboutUs') {
                    height = Number(height) - 200 - Number(ScrollAmount);
                }
                break;
            case 'OurMission':
                if (PageID == 'Index') {
                    height = Number(height) - 110 - Number(ScrollAmount);
                } else if (PageID == 'AboutUs') {
                    height = Number(height) - 200 - Number(ScrollAmount);
                }
                break;

            default:
        }
        //height = $(window).innerHeight();
        var sum = Number(offs) + Number(height);
        $('html, body').animate({ scrollTop: sum }, 'slow');
    }
    catch (err) {
        //document.getElementById("demo").innerHTML = err.message;
        alert(err.message);
    }
}
