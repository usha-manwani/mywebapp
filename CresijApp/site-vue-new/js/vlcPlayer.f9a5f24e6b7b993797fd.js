(function(e){function t(t){for(var a,i,l=t[0],c=t[1],u=t[2],p=0,h=[];p<l.length;p++)i=l[p],Object.prototype.hasOwnProperty.call(r,i)&&r[i]&&h.push(r[i][0]),r[i]=0;for(a in c)Object.prototype.hasOwnProperty.call(c,a)&&(e[a]=c[a]);d&&d(t);while(h.length)h.shift()();return o.push.apply(o,u||[]),n()}function n(){for(var e,t=0;t<o.length;t++){for(var n=o[t],a=!0,l=1;l<n.length;l++){var c=n[l];0!==r[c]&&(a=!1)}a&&(o.splice(t--,1),e=i(i.s=n[0]))}return e}var a={},r={vlcPlayer:0},o=[];function i(t){if(a[t])return a[t].exports;var n=a[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,i),n.l=!0,n.exports}i.m=e,i.c=a,i.d=function(e,t,n){i.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},i.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},i.t=function(e,t){if(1&t&&(e=i(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(i.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var a in e)i.d(n,a,function(t){return e[t]}.bind(null,a));return n},i.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return i.d(t,"a",t),t},i.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},i.p="/site-vue-new/";var l=window["webpackJsonp"]=window["webpackJsonp"]||[],c=l.push.bind(l);l.push=t,l=l.slice();for(var u=0;u<l.length;u++)t(l[u]);var d=c;o.push([9,"chunk-vendors"]),n()})({"4d53":function(e,t,n){function a(e){var t=new RegExp("(^|&)"+e+"=([^&]*)(&|$)"),n=window.location.search.substr(1).match(t);return null!=n?unescape(n[2]):null}n("b4fb"),n("84c2"),n("e35a"),n("1c2e"),n("f4e3"),n("9cf3"),n("a133"),n("ed0d"),n("f09c"),n("e117"),$(document).ready((function(){var e={width:a("width"),height:a("height"),id:a("id"),vedioAddr:a("vedioAddr")};setTimeout((function(){$("#player").css({height:e.height+"px",width:e.width+"px",display:"inline-block"}),$("#player").html('<object classid="clsid:9BE31822-FDAD-461B-AD51-BE1D1C159921" \n              style = "position:relation;z-index: -1;left:13px"\n                width="'.concat(e.width,'" height="').concat(e.height,'" id="embed').concat(e.id,'" >\n                <param name="MRL" value="').concat(e.vedioAddr,'"></param>\n                <param name="ShowDisplay" value="True" ></param>\n                <param name="AutoLoop" value="False" ></param>\n                <param name="AutoPlay" value="True" ></param>\n                <param name="Volume" value="50" ></param>\n                <param name="Toolbar" value="False" ></param>\n                <param name="StartTime" value="0" ></param>\n                <embed pluginspage="http://www.videolan.org"\n                       type="application/x-vlc-plugin"\n                       width="').concat(e.width,'"\n                       height="').concat(e.height,'"\n                       toolbar="false"\n                       loop="false"\n                       branding="true"\n                       text="Waiting for video"\n                       bgcolor="#0000ff"\n                       allowfullscreen="true"\n                       name="embed').concat(e.id,'"></embed></object>')),setTimeout((function(){$("#embed".concat(e.id)).attr({height:e.height,width:e.width}),$("#embed".concat(e.id)).css({height:e.height+"px",width:e.width+"px"}),$("html,body").css({height:e.height+"px",width:e.width+"px"})}),100)}),1*e.id)}))},9:function(e,t,n){e.exports=n("4d53")}});