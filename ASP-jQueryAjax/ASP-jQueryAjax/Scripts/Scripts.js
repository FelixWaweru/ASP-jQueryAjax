function ShowImagePreview(imageUploader, previewimage)
{
    if (imageUploader.files && imageUploader.files[0])
    {
        var reader = new FileReader();
        reader.onload = function (e)
        {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function JQueryAjaxPost(form)
{
    $.validator.unobtrusive.parse(form);
    if (form.valid())
    {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {
                $('#firstTab').html(response);
            }
        }
        if ($(form).attr('enctype ') == "multiart/form-data")
        {
            ajaxConfig['contentType'] = false;
            ajaxConfig['processData'] = false;
        }
        $.ajax(ajaxConfig);
    }

    return false;
}