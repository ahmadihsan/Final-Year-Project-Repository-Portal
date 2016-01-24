function ReturnTime(timeStr, addTime) {
    var hour, minute;
    var indexofam = timeStr.indexOf("am");
    var indexofpm = timeStr.indexOf("pm");
    var amorpm = '';
    timeStr = timeStr.replace("am", "");
    timeStr = timeStr.replace("pm", "");
    hour = parseInt(timeStr.substr(0, timeStr.indexOf(':')));
    minute = parseInt(timeStr.substr(timeStr.indexOf(':') + 1));
    addTime = parseInt(addTime);
    minute = (minute + addTime);
    var beforeChangehour = hour;
    if (indexofpm != -1) {

        if (minute > 59) {
            hour = hour + 1;
            minute = minute - 60;
        }
        if (hour == 12 && beforeChangehour < 12) {
            amorpm = 'am';
            //hour = hour - 12;
        }
        else
            amorpm = 'pm';
        if(hour>12) {
            hour = hour - 12;
        }
        


    }
    if (indexofam != -1) {

        if (minute > 59) {
            hour = hour + 1;
            minute = minute - 60;
        }
        if (hour == 12 && beforeChangehour < 12) {
            amorpm = 'pm';
            //hour = hour - 12;
        }
        else
            amorpm = 'am';
        if (hour > 12) {
            hour = hour - 12;
        }
        

    }
    var min = minute.toString();
    if (parseInt(minute) == 0) {
        min = "00";
    }
    var ret = hour + ":" + min + "" + amorpm;
    return ret;

}