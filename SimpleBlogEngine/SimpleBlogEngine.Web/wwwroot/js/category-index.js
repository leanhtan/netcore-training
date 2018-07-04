(function ($) {
  function Category() {
    var $this = this;

    function initilizeModel() {
      $("#modal-action-category").on('loaded.bs.modal', function (e) {
        $.validator.unobtrusive.parse($(this).find("form")[0]);
      });
      $("#modal-action-category").on('hidden.bs.modal', function (e) {
        $(this).removeData('bs.modal')
      });
    }
    $this.init = function () {
      initilizeModel();
    }
  }
  $(function () {
    var self = new Category();
    self.init();
  })
}(jQuery))
