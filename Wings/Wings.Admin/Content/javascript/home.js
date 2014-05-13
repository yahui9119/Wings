/// <reference path="jquery-1.7.1.min.js" />
$(document).ready(function () {
    //这是一个整页面加入淡入效果
    $('body').hide().fadeIn(1000);
    showTime();
    hoverTopMenu();
    logOut();
    memo();
    onlineState();
});

//阻止默认事件
function stopPreventDefault(e) {
        //如果提供了事件对象，则这是一个非IE浏览器   
        if (e && e.preventDefault) {
            //阻止默认浏览器动作(W3C)  
            e.preventDefault();
        } else {
            //IE中阻止函数器默认动作的方式   
            window.event.returnValue = false;
        }
        return false;
}
//设置时间
function showTime() {
    var now = new Date();
    var months = now.getMonth() + 1;
    var days = now.getDate();
    var hours = now.getHours();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();
    var str = now.getFullYear() + "-" + (months < 10 ? ("0" + months) : months) + "-" + (days < 10 ? ("0" + days) : days) + " " + (hours < 10 ? ("0" + hours) : hours) + ":" + (minutes < 10 ? ("0" + minutes) : minutes) + ":" + (seconds < 10 ? ("0" + seconds) : seconds);
    document.getElementById('nowDate').innerHTML = str;
    setTimeout('showTime()', 1000);
}
//右上角划过菜单
function hoverTopMenu() {
    var len = $('#topMenu>ul>li').length;
    $('#topMenu>ul>li').each(function (i) {
        var curObj = null;
        var preObj = null;
        var openedTimer = null;
        $(this).hover(function () {
            curObj = $(this);
            var left = curObj.find('span').offset().left - 2;
            var right = $(document).width() - left;
            var div_width = curObj.find('div').outerWidth();
            if (right < div_width) {
                left = left - curObj.find('div').outerWidth() + curObj.find('span').outerWidth() + 2;
            }
            var top = curObj.find('span').offset().top - 1 + curObj.find('span').outerHeight();
            if (openedTimer) {
                clearTimeout(openedTimer);
            }
            openedTimer = setTimeout(function () {
                curObj.find('div').css({ 'left': left, 'top': top }).slideDown('fast');
                curObj.find('span>i').removeClass('b-icon-white').removeClass('b-icon-chevron-down').addClass('b-icon-chevron-up');
                curObj.children('a').css('background-position', '0% -42px').find("span").css({ 'background-position': '100% -42px', 'color': '#fff' });
            }, 100);
            preObj = curObj;
        }, function () {
            if (openedTimer) {
                clearTimeout(openedTimer);
            }
            openedTimer = setTimeout(function () {
                preObj.find('div').slideUp('fast');
                curObj.find('span>i').addClass('b-icon-white').removeClass('b-icon-chevron-up').addClass('b-icon-chevron-down');
                curObj.children('a').removeAttr('style').find('span').removeAttr('style');
            }, 100);
        });
    });
}


function logOut() {
    $('#logging-out').on('click', function () {
        stopPreventDefault();
        $.messager.confirm('安全提示', '是否退出系统？', function (r) {
            if (r) {
                window.location = $('#logging-out').attr('href');
            } 
        });
    });
}

//个人便笺
function memo() {
    $('#personal-memo').on('click', function () {
        $('#gwkm-memo').window('open');
    });
    $('#btnMemo').on('click', function () {
        var txtMemo = $('#txtMemo').val();
        if (txtMemo.length < 1) {
            $.messager.alert('提示', '请输入便笺之后再提交!', 'info');
        } else {
            $.post('/User/Memo',
                { memo: txtMemo, userID: $('#userID').val(), userName: $('#userName').val() },
                function (data) {
                    if (data.success) {
                        $.messager.alert('提示', data.message, 'info', function () { $('#gwkm-memo').window('close'); });
                    } else {
                        $.messager.alert('错误', data.message, 'error');
                    }
            });
        }
    });
}

//在线状态及个性签名
function onlineState() {
    $('#personal-state').on('click', function () {
        $('#gwkm-state').window('open');
    });
    $('#stateselect>a').on('click', function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var rel = $(this).attr('rel');
        $('#onlineState').val(rel);
    });
    $('#btnState').on('click', function () {
        var txt = $('#txtSignature').val();
        if (txt.length < 1) {
            $.messager.alert('提示', '请输入个性签名之后再提交!', 'info');
        } else {
            $.post('/User/OnlineState',
                { signature: txt, userID: $('#userID').val(), onlineState: $('#onlineState').val() },
                function (data) {
                    if (data.success) {
                        $.messager.alert('提示', data.message, 'info', function () { $('#gwkm-state').window('close'); });
                    } else {
                        $.messager.alert('错误', data.message, 'error');
                    }
                });
        }
    });
}

