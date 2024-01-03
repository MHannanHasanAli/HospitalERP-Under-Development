$(document).ready(function () {
   
    /*card search*/
    $("#search").on("input", function () {

        var searchText = $(this).val().toLowerCase();
        var searchColumn = $("#searchColumn").val().toLowerCase();

        $(".searchit tr").filter(function () {
            // Get the text content of the cell in the selected column
            var cellText = $(this).find("td:eq(" + $("#searchColumn option:selected").index() + ")").text().toLowerCase();

            // Show/hide the row based on the search criteria
            $(this).toggle(cellText.indexOf(searchText) > -1);
        });
    });

    /*three dots into menu*/
    $(".options").click(function () {
        var itemId = $(this).data("item-id");

        // Hide all other options before showing the current one
        $(".button-section").not("[data-item-id='" + itemId + "']").addClass("hidden");
        $(".hidden-buttons").not("[data-item-id='" + itemId + "']").addClass("hidden");

        // Toggle visibility for options of the clicked card
        $(".button-section[data-item-id='" + itemId + "']").toggleClass("hidden");
        $(".hidden-buttons[data-item-id='" + itemId + "']").addClass("hidden");
    });
});

function calculateAge() {
    // Get the selected date from the input field
    var selectedDate = new Date(document.getElementById('DateOfBirth').value);

    // Get the current date
    var currentDate = new Date();

    // Calculate the age
    var age = currentDate.getFullYear() - selectedDate.getFullYear();

    // Adjust age if birthday hasn't occurred yet this year
    if (currentDate.getMonth() < selectedDate.getMonth() ||
        (currentDate.getMonth() === selectedDate.getMonth() && currentDate.getDate() < selectedDate.getDate())) {
        age--;
    }

    // Display the calculated age
    document.getElementById('Age').value = age;
}