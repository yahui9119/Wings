/// <reference path="jquery-1.7.1.min.js" />
var Common = {
    formFocus: function (id) {
        $("#" + id + " input[type='text'],#" + id + " input[type='password'],#" + id + " textarea[rel='validate']").each(function () {
            var $t = $(this);
            $t.focus(function () {
                $t.parent().parent().removeClass("error").addClass("info");
                $t.next().html($t.attr("focusText"));
            }).blur(function () {
                $t.parent().parent().removeClass("error").removeClass("info");
                $t.next().html("");
            });
        });
        $("#" + id + " button[type='submit']").click(function () {
            $("#" + id + " input[type='text'][rel='validate'],#" + id + " input[type='password'],#" + id + " textarea[rel='validate']").each(function () {
                var $q = $(this);
                var len = $q.val().length;
                var errorInfo;
                if (typeof $q.attr("errorText") != "undefined") {
                    errorInfo = $q.attr("errorText");
                } else {
                    errorInfo = $q.attr("focusText");
                }
                if (typeof $q.attr("Regex") != "undefined") {
                    var v = $q.val();
                    if (v != "#") {
                        var regUrl = new RegExp();
                        regUrl.compile($q.attr("Regex"));
                        if (!regUrl.test(v)) {
                            $q.parent().parent().removeClass("info").addClass("error");
                            $q.next().html(errorInfo);
                            Common.preventDefault();
                        }
                    }
                }
                if (typeof $q.attr("minLength") != "undefined") {
                    var minLength = parseInt($q.attr("minLength"));
                    if (len < minLength) {
                        $q.parent().parent().removeClass("info").addClass("error");
                        $q.next().html(errorInfo);
                        Common.preventDefault();
                    }
                }
                if (id == "HavePasswordSubmit") {
                    var v1 = $("#Password").val();
                    var v2 = $("#Password1").val();
                    if (v1 != v2) {
                        $("#Password1").parent().parent().removeClass("info").addClass("error");
                        $("#Password1").next().html("两次密码输入不一致！");
                        Common.preventDefault();
                    }
                }
            });
            //编辑器输入长度判断
            if ($("#kind-editor").length > 0) {
                var $editor = $("#kind-editor");
                var l = editor.html().length;
                var error;
                if (typeof $editor.attr("errorText") != "undefined") {
                    error = $editor.attr("errorText");
                } else {
                    error = $editor.attr("focusText");
                }
                if ($editor.attr("minLength") != "undefined") {
                    if (l < parseInt($editor.attr("minLength"))) {
                        $editor.parent().parent().addClass("error");
                        $editor.next().html(error);
                        Common.preventDefault();
                    } else {
                        $editor.parent().parent().removeClass("error");
                        $editor.next().html("");
                    }
                } else if ($editor.attr("maxlength") != "undefined") {
                    if (l > parseInt($editor.attr("maxlength"))) {
                        $editor.parent().parent().removeClass("info").addClass("error");
                        $editor.next().html(error);
                        Common.preventDefault();
                    } else {
                        $editor.parent().parent().removeClass("error");
                        $editor.next().html("");
                    }
                }
            }
        });
    },
    getIcon: function () {
        $('#Icon').focus(function () {
            $('#select-icon-list').css({ 'left': $(this).offset().left, 'top': $(this).offset().top + $(this).outerHeight() }).fadeTo(0, 0.9).fadeIn('fast');
        });
        $('#select-icon-close').on('click', function () {
            $('#select-icon-list').fadeOut('fast');
        });
        $('#select-icon-list>div.icon-list>a').on('click', function () {
            var icon = $(this).attr('id');
            $('#Icon').val(icon);
            $('#Icon').next().next().find('a').removeClass().addClass('t-icon').addClass(icon);
            $('#select-icon-list').fadeOut('fast');
        });
    },
    getEvent: function (event) {
        return event ? event : window.event;
    },
    preventDefault: function (event) {
        var event = Common.getEvent();
        if (event.preventDefault) {
            event.preventDefault();
        } else {
            event.returnValue = false;
        }
    },
    stopPropagation: function () {
        var event = Common.getEvent();
        if (event.stopPropagation) {
            event.stopPropagation();
        } else {
            event.cancelBubble = true;
        }
    }
};

//拼接字符串，效率比较高，所以可以推荐使用这个，也可以使用传统的+拼接
function StringBuffer() {
    this._strings_ = new Array();
}
StringBuffer.prototype.append = function (str) {
    this._strings_.push(str);
};
//可以传递分隔符，也可以不传递
StringBuffer.prototype.toString = function () {
    if (arguments.length == 0) {
        return this._strings_.join("");
    } else {
        return this._strings_.join(arguments[0]);
    }
};