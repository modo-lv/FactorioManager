$(() => {
  $("button.AutofillGameHome").on("click", (e) => {
    let target = $(e.target).data('target');
    $.get("/api/config/game_home").done(p => $(target).val(p));
  })
})