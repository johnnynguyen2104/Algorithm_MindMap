var a = 'dasdasda';
if (a) {
    alert("dsadasda");
}

function boxBlur(image) {
    var row = image.length
        , column = image[0].length
        , resultR = 0, resultC = 0;

    var temp = 0;
    var result = new Array(row - 2);

    for (var i = 0; i < row - 2; i++) {
        result[resultR] = new Array(column - 2);
        for (var j = 0; j < column - 2; j++) {

            for (var d = 0; d < 3; d++) {
                temp += image[i][j + d];
                temp += image[i + 1][j + d];
                temp += image[i + 2][j + d];
            }
            result[resultR][resultC] = temp / 9;
            resultC++;
            temp = 0;
        }
        resultC = 0;
        resultR++;
    }

    return result;
}

var a = [[1, 1, 1],
[1, 7, 1],
[1, 1, 1]];
boxBlur(a);