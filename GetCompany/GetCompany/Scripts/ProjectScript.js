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
        alert("Fill out Project name and Project manager") 
        event.preventDefault();
    } 

}

function AddTask() {
    var idproject = document.getElementById("IDProject").value;
    var assignee = document.getElementById("Assignee").value;
    var deadline = document.getElementById("Deadline").value;
    var description = document.getElementById("Description").value;
    if (idproject === "" || assignee === "" || deadline === "" || description==="") {
        if (idproject === "") {
            document.getElementById("IDProject").style.border = "1px solid red";
        }
        else {
            document.getElementById("IDProject").style.border = "";
        }

        if (description === "") {
            document.getElementById("Description").style.border = "1px solid red";
        }
        else {
            document.getElementById("Description").style.border = "";
        }


        if (assignee === "") {
            document.getElementById("Assignee").style.border = "1px solid red";
        }
        else {
            document.getElementById("Assignee").style.border = "";
        }


        if (deadline === "") {
            document.getElementById("Deadline").style.border = "1px solid red";
        }
        else {
            document.getElementById("Deadline").style.border = "";
        }
        alert("Fill out all red fields.")
        event.preventDefault();
    }

}