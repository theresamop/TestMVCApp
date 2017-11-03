
var clickCOunt = $("#ClickCount").val();
    
    function ClickCounter() {
      //  clickCOunt = $("#ClickCount").val();
        $("#txtCounter").val(clickCOunt);
        if (clickCOunt < 10) {
            $.ajax({
                url: "Test/TestCounter",

            }).success(function (result) {
                // $("#ClickCount").val(result);
                clickCOunt = result;
                $("#txtCounter").val(result);
            }).fail(function () {
                alert("error");
            });
        }
        else alert("exceeded max clicks allowed!");
    }

    function Reset() {
       
        
            $.ajax({
                url: "Test/ResetCntr",

            }).success(function (result) {
                clickCOunt = result;
                $("#txtCounter").val(result);
            }).fail(function () {
                alert("error");
            });
    
  
    }

    $(document).ready(function () {
        clickCOunt = $("#ClickCount").val();
        $("#txtCounter").val(clickCOunt);
    });
