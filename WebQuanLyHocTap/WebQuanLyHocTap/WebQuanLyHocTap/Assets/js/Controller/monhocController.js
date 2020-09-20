var monhoc = {
    init: function () {
        monhoc.ham();
    },
    ham: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/MonHoc/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type:"POST",
              
                success: function (response) {
                    console.log(response);
                    if (response.islock == true) {
                        $(this).text('đang khóa');
                    }
                    else {
                        $(this).text('mở khóa');
                    }
                }
            });
        });
    }
}