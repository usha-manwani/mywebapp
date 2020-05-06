function SubmitInfo() {
    var scname = document.getElementsByName("SchoolName");
    var scengname = document.getElementsByName("SchoolEngName");
    var logo = document.getElementsByName("SchoolLogo");
}
var dataString;
$('#schoolLogo').on('change', function (e) {
    var files = e.target.files;
    
    var myID = 3; //uncomment this to make sure the ajax URL works
    if (files.length > 0) {
        if (window.FormData !== undefined) {
            reader.readAsArrayBuffer(files[0]);

            $.ajax({
                type: "POST",
                url: '../Services/getOrganisationData.asmx/GetStudentDat?id=' + myID,
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    console.log(result);
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        } else {
            alert("This browser doesn't support HTML5 file uploads!");
        }
    }
});

var reader = new FileReader();

reader.addEventListener("load", function () {
    dataString = reader.result;
    console.log("file read success");
}, false);

