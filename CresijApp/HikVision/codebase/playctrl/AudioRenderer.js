// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 12-09-2019
//
// Last Modified By : admin
// Last Modified On : 12-09-2019
// ***********************************************************************
// <copyright file="AudioRenderer.js" company="Microsoft">
//     Copyright ? Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <var>The create class</var>
/// <summary>
/// </summary>
/// <summary>
/// es the specified e.
/// </summary>
/// <param name="e">The e.</param>
/// <param name="t">The t.</param>
/// <summary>
/// </summary>
/// <param name="t">The t.</param>
/// <param name="n">The n.</param>
/// <param name="i">The i.</param>
/// <summary>
/// Classes the call check.
/// </summary>
/// <param name="e">The e.</param>
/// <param name="t">The t.</param>
/// <var>The instance</var>
/// <summary>
/// </summary>
/// <summary>
/// </summary>
/// <param name="t">The t.</param>
/// <var>The audio renderer</var>
/// <summary>
/// </summary>
/// <summary>
/// es this instance.
/// </summary>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <param name="t">The t.</param>
/// <param name="n">The n.</param>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <param name="t">The t.</param>
/// <param name="n">The n.</param>
/// <summary>
/// es the specified t.
/// </summary>
/// <param name="t">The t.</param>
/// <param name="n">The n.</param>
/// <param name="i">The i.</param>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <summary>
/// </summary>
/// <param name="e">The e.</param>
/// <summary>
/// es this instance.
/// </summary>
/// <summary>
/// es the specified t.
/// </summary>
/// <param name="t">The t.</param>
/// <summary>
/// es the specified t.
/// </summary>
/// <param name="t">The t.</param>
/// <summary>
/// es this instance.
/// </summary>
"use strict";var _createClass=function(){function e(e,t){for(var n=0;n<t.length;n++){var i=t[n];i.enumerable=i.enumerable||false;i.configurable=true;if("value"in i)i.writable=true;Object.defineProperty(e,i.key,i)}}return function(t,n,i){if(n)e(t.prototype,n);if(i)e(t,i);return t}}();function _classCallCheck(e,t){if(!(e instanceof t)){throw new TypeError("Cannot call a class as a function")}}var __instance=function(){var e=void 0;return function(t){if(t)e=t;return e}}();var AudioRenderer=function(){function e(){_classCallCheck(this,e);if(__instance())return __instance();if(e.unique!==undefined){return e.unique}e.unique=this;this.oAudioContext=null;this.currentVolume=.8;this.bSetVolume=false;this.gainNode=null;this.iWndNum=-1;this.mVolumes=new Map;var t=window.AudioContext||window.webkitAudioContext;this.oAudioContext=new t;this.writeString=function(e,t,n){for(var i=0;i<n.length;i++){e.setUint8(t+i,n.charCodeAt(i))}};this.setBufferToDataview=function(e,t,n){for(var i=0;i<n.length;i++,t++){e.setUint8(t,n[i])}};__instance(this)}_createClass(e,[{key:"Play",value:function e(t,n,i){var r=new ArrayBuffer(44+n);var u=new DataView(r);var o=i.samplesPerSec;var a=i.channels;var s=i.bitsPerSample;this.writeString(u,0,"RIFF");u.setUint32(4,32+n*2,true);this.writeString(u,8,"WAVE");this.writeString(u,12,"fmt ");u.setUint32(16,16,true);u.setUint16(20,1,true);u.setUint16(22,a,true);u.setUint32(24,o,true);u.setUint32(28,o*2,true);u.setUint16(32,a*s/8,true);u.setUint16(34,s,true);this.writeString(u,36,"data");u.setUint32(40,n,true);this.setBufferToDataview(u,44,t);var l=this;this.oAudioContext.decodeAudioData(u.buffer,function(e){var t=l.oAudioContext.createBufferSource();if(t==null){return-1}t.buffer=e;t.start(0);if(l.gainNode==null||l.bSetVolume){l.gainNode=l.oAudioContext.createGain();l.bSetVolume=false}l.gainNode.gain.value=l.currentVolume;l.gainNode.connect(l.oAudioContext.destination);t.connect(l.gainNode)},function(e){console.log("decode error");return-1});return 0}},{key:"Stop",value:function e(){if(this.gainNode!=null){this.gainNode.disconnect();this.gainNode=null}return true}},{key:"SetVolume",value:function e(t){this.bSetVolume=true;this.currentVolume=t;this.mVolumes.set(this.iWndNum,t);return true}},{key:"SetWndNum",value:function e(t){this.iWndNum=t;var n=this.mVolumes.get(t);if(n==undefined){n=.8}this.currentVolume=n;return true}},{key:"GetVolume",value:function e(){var t=this.mVolumes.get(this.iWndNum);if(t==undefined){t=.8}return t}}]);return e}();