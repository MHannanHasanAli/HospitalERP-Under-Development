$(document).ready(function () {
   
    /*card search*/
    $("#search").on("input", function () {
        var value = $(this).val().toLowerCase();
        var column = $("#searchColumn").val();

        if (column === null) {
            column = "Name";
        }

        $(".searchit").filter(function () {
            var cardId = $(this).find("#" + column).text().toLowerCase();
            $(this).toggle(cardId.includes(value));
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