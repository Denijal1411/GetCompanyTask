function visiblePassword() {
    var x = document.getElementById("Password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
} 

function AddProject() { 
    var assignee = document.getElementById("Assignee").value;
    var name = document.getElementById("Name").value;
    if (name === "" || assignee === "") { 
        if (name === "")
        {
            document.getElementById("Name").style.border = "1px solid red";
        }
        else {
            document.getElementById("Name").style.border = "";
        }
        if (assignee === "") {
            document.getElementById("Assignee").style.border = "1px solid red";
        }
        else {
            document.getElementById("Assignee").style.border = "";
        }
        document.getElementById("messageName").innerHTML = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
            "<span><strong>Fill out </strong> Project name and Project manager </span><button type='button' class='close' data-dismiss='alert' aria-label='Close'>" +
            " <span aria-hidden='true'>&times;</span></button></div>"; 

        event.preventDefault();
    } 

}