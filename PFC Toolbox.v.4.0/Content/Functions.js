
// Function to check for integer value.
function integerCheck(value) {
    return /^\d+$/.test(value);
}

// Function to check for float value.
function floatCheck(value) {
    if (!isNaN(value)) {
        if (value % 1 != 0) {
            return true;
        }
    }
}

// Function to truncate decimals without rounding
function toFixed(num, fixed) {
    var re = new RegExp('^-?\\d+(?:\.\\d{0,' + (fixed || -1) + '})?');
    return num.toString().match(re)[0];
}

// Function to pad numbers with 0's
function pad(number, width = 3, z = 0) {
    return (String(z).repeat(width) + String(number)).slice(String(number).length)
}

// Function to remove special characters
function removeSpecials(string) {
    return string.replace(/[^a-zA-Z0-9,:\- ]/g, "");
};

// Function to convert fields to title case and remove special characters
function titleCase(string) {
    return string.replace(
        /\w\S*/g,
        function (txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        }
    ).replace("&", "and")
        .replace(/[^a-zA-Z0-9 ]/g, "")
        .replace("And", "and")
        .replace("Rbgh", "rBGH")
        .replace("Bbq", "BBQ")
        .replace("Ipa", "IPA")
        .replace("Cbd", "CBD");
};

// Function to format case cost field
function caseCostFormatter(string) {
    return string.replace(/[^0-9.]/g, "")
        .replace("NA", "")
        .replace("na", "");
};

// Function to format size field
function sizeFormatter(string) {
    return string.replace(/[^.a-zA-Z0-9- ]/g, "")
        .replace("count", "ct.")
        .replace("Ea", "ea")
        .replace("each", "ea")
        .replace("Each", "ea")
        .replace("pack", "pk.")
        .replace("pounds", "lbs.")
        .replace("pound", "lb.")
        .replace("ounces", "oz.")
        .replace("ounce", "oz.")
        .replace("liters", "L.")
        .replace("liter", "L.")
        .replace("Liter", "L.");
};

// Function to limit field length
function limitLength(string, max) {
    if (string.length > max) {
        string = string.substr(0, max);
    };

    return string;
};

// Function to get today's date
function getDate() {
    today = new Date().getMonth() + 1
        + "/" + new Date().getDate()
        + "/" + new Date().getFullYear()
        + " " + new Date().getHours()
        + ":" + new Date().getMinutes()
        + ":" + new Date().getSeconds()
    return today;
};