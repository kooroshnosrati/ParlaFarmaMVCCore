var TotalSum = 0;
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
        var sum = Number(offs) + Number(height);

        switch (TagID) {
            case 'SocialResponsibility':
                if (!FromOwn) {
                    sum = Number(sum) + 2002;
                    break;
                }
            case 'OurCulture':
                if (!FromOwn) {
                    sum = Number(sum) + 1241;
                    break;
                }
            case 'ParlaTeam':
                if (PageID == 'Index') {
                    console.log(2);
                    sum = Number(sum) - 200;
                    break;
                }
                if (!FromOwn) {
                    console.log(1);
                    sum = Number(sum) + 2883;
                    break;
                }
            case 'OurValues':
                if (!FromOwn) {
                    sum = Number(sum) + 342;
                    break;
                }
                
            case 'OurVision':
            case 'OurMission':
            case 'AboutParla':
            case 'Distributors':
            case 'ExportDevelopment':
                if (FromOwn) {
					console.log('FromOwn');
                    sum = Number(sum) - 110;
                }
                else {
					console.log('! FromOwn');
                    sum = Number(sum) - 220;
                }
                break;
            case 'Vacancies':
            case 'WhyPARLA':
                if (FromOwn) {
					console.log('FromOwn');
                    sum = Number(sum) - 110;
                }
                else {
					console.log('! FromOwn');
                    sum = Number(sum) - 220 + 562;
                }
                break;
            default:
        }
        //if (!FromOwn) {
        //    sum = Number(sum) + 110;
        //}




        console.log('PageID:' + PageID + ' TagID:' + TagID + ' Sum :' + sum);

        //console.log('Start First Scroll');
        $('html, body').animate({ scrollTop: sum + 'px' }, 'slow', animateCallback(sum)); //
        //console.log('End First Scroll ');

        TotalSum = sum;

    }
    catch (err) {
        //document.getElementById("demo").innerHTML = err.message;
        console.log(err.message);
    }
}


function animateCallback(sum) {
    //console.log('Start Second Scroll');
    //$('html, body').animate({ scrollTop: sum + 'px' }, 'slow');
    //console.log('End Second Scroll ');
    TotalSum = sum;
}


function myfunction() {
    //console.log('myfunction');
    $('html, body').animate({ scrollTop: TotalSum + 'px' }, 'slow');
}


window.onload = function () { // same as window.addEventListener('load', (event) => {
    setTimeout(myfunction(), 10000);
};
