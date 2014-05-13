/// <reference path="jquery-1.7.1.min.js" />
$(document).ready(function () {
    //这是一个整页面加入淡入效果
    $('body').hide().fadeIn(1000);
    leftMenu();
    showTime();
    hoverTopMenu();
    tabActionOpearte();
    tabActionEvent();
    logOut();
    memo();
    onlineState();
});
var onlyOpenTitle = "我的首页";
//给左菜单绑定click事件
function leftMenu() {
    $('#leftMenu ul a').each(function (i, ele) {
        var $this = $(ele);
        $this.on('click', function () {
            var url = $this.attr('rel');
            var title = $this.attr('title');
            var icon = $this.parent().prev().attr('class');
            showTab(url, title, icon);
        });
    });
}
//像浏览器一样显示tab
function showTab(url, title, icon) {
    var tab = $('#tabs');
    if (tab.tabs('exists', title)) {
        tab.tabs('select', title);
    } else {
        tab.tabs('add', {
            title: title,
            content: createFrame(url),
            iconCls: icon,
            closable: true
        });
    }
    tabActionOpearte();
}
//创建iframe
function createFrame(url) {
    var s = '<iframe name="sysMain" scrolling="yes" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
    return s;
}
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

function tabActionOpearte() {
    /*双击关闭TAB选项卡*/
    $('.tabs-inner').dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
    /*为选项卡绑定右键*/
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#gwkm-tab-menu').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subtitle = $(this).children(".tabs-title").text();
        var currentTab = $('#tabs').tabs('getSelected');
        var alltabs = $('#tabs').tabs('tabs');
        var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);
        //点击首页
        if (subtitle == onlyOpenTitle) {
            $("#close,#close-left").css('color', "#ccc");
            //只有一个首页
            if (alltabs.length == 1) {
                $("#close-right,#close-other,#close-all").css('color', '#ccc');
            } else if (alltabs.length > 1) {
                $("#close-right,#close-other,#close-all").css('color', '#000');
            }
        } else {
            if (alltabs.length == 2) {
                $("#close,#close-all").css('color', '#000');
                $("#close-left,#close-right,#close-other").css('color', '#ccc');
            } else if (alltabs.length > 2) {
                if (tabIndex == alltabs.length - 1) {
                    $("#close,#close-all,#close-other,#close-left").css('color', '#000');
                    $("#close-right").css('color', '#ccc');
                } else {
                    if (tabIndex != 1) {
                        $("#close,#close-all,#close-other,#close-left,#close-right").css('color', '#000');
                    } else {
                        $("#close,#close-all,#close-other,#close-right").css('color', '#000');
                        $("#close-left").css('color', '#ccc');
                    }
                }
            }
        }
        $('#gwkm-tab-menu').data("currtab", subtitle);
        $('#tabs').tabs('select', subtitle);
        return false;
    });
}
//tab动作的操作
function tabActionEvent() {
    $('#gwkm-tab-menu').menu({
        onClick: function (item) {
            actionTab(item.id);
        }
    });
}
//tab动作的操作
function actionTab(action) {
    var alltabs = $('#tabs').tabs('tabs');
    var currentTab = $('#tabs').tabs('getSelected');
    var allTabtitle = [];
    $.each(alltabs, function (i, n) {
        allTabtitle.push($(n).panel('options').title);
    });
    switch (action) {
        case 'refresh':
            var iframe = $(currentTab.panel('options').content);
            var src = iframe.attr('src');
            if (currentTab.panel('options').title == onlyOpenTitle)//如果是我的首页
            {
                src = '/Home/Main';
            }
            $('#tabs').tabs('update', {
                tab: currentTab,
                options: {
                    content: createFrame(src)
                }
            })
            break;
        case 'close':
            var currtab_title = currentTab.panel('options').title;
            if (currtab_title != onlyOpenTitle) {//首页无法关闭
                $('#tabs').tabs('close', currtab_title);
            }
            break;
        case 'close-all':
            $.each(allTabtitle, function (i, n) {
                if (n != onlyOpenTitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break;
        case 'close-other':
            var currtab_title = currentTab.panel('options').title;
            $.each(allTabtitle, function (i, n) {
                if (n != currtab_title && n != onlyOpenTitle) {
                    $('#tabs').tabs('close', n);
                }
            });
            break;
        case 'close-right':
            var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);
            if (tabIndex == alltabs.length - 1) {
                $.messager.alert('提示', '右边没有可关闭的tab项', 'info');
                return false;
            }
            $.each(allTabtitle, function (i, n) {
                if (i > tabIndex) {
                    if (n != onlyOpenTitle) {
                        $('#tabs').tabs('close', n);
                    }
                }
            });
            break;
        case 'close-left':
            var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);
            if (tabIndex == 1) {
                $.messager.alert('提示', '左边边没有可关闭的tab项', 'info');
                return false;
            }
            $.each(allTabtitle, function (i, n) {
                if (i < tabIndex) {
                    if (n != onlyOpenTitle) {
                        $('#tabs').tabs('close', n);
                    }
                }
            });
            break;
        case 'exit':
            $('#gwkm-tab-menu').menu('hide');
            break;
    }
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

