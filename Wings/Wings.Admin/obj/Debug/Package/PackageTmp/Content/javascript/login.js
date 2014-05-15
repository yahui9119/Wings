/// <reference path='jquery-1.7.1.min.js' />
$(document).ready(function () {
    //刷新验证码
    $('#txtCode').focus(function () {
        $('#verifycode-layer').css({ 'left': $(this).offset().left + 30, 'top': $(this).offset().top + $(this).outerHeight() });
        $('#verifycode-layer').fadeTo(0, 0.8).fadeIn('slow');
    });
    $('#verifycode-refesh').on('click',function () {
        $('#verifycode').attr('src', '/Common/GetVerifyCode?t=' + (new Date()).getTime());
    });
    $('#verifycode-close').on('click',function () {
        $('#verifycode-layer').fadeOut('fast');
    });
    $(window).resize(function () {
        $('#verifycode-layer').css({ 'left': $('#txtCode').offset().left + 30, 'top': $('#txtCode').offset().top + $('#txtCode').outerHeight() });
    });
    $('#login>div.alert>button').on('click', function () {
        $(this).parent().fadeOut('slow');
    });

    //记住我
    $('#rememberChk').on('click', function () {
        var select = $(this).attr('checked') == 'checked';
        $('#remember').val(select);
    });

    //登录判断
    $('#login-submit').on('click', function () {
        if ($('#UserName').val().length < 4) {
            $('#login>div.alert').fadeIn('slow')
                .removeClass('alert-info').addClass('alert-error')
                .find('>span').html('用户名长度至少4位');
            return false;
        } else if ($('#Password').val().length < 6) {
            $('#login>div.alert').fadeIn('slow')
                .removeClass('alert-info').addClass('alert-error')
                .find('>span').html('密码长度至少6位');
            return false;
        } else if ($('#txtCode').val().length < 4) {
            $('#login>div.alert').fadeIn('slow')
                .removeClass('alert-info').addClass('alert-error')
                .find('>span').html('验证码长度为4位');
            return false;
        }
    });
});