!function(t,n){for(var e in n)t[e]=n[e]}(window,function(t){var n={};function e(o){if(n[o])return n[o].exports;var i=n[o]={i:o,l:!1,exports:{}};return t[o].call(i.exports,i,i.exports,e),i.l=!0,i.exports}return e.m=t,e.c=n,e.d=function(t,n,o){e.o(t,n)||Object.defineProperty(t,n,{enumerable:!0,get:o})},e.r=function(t){"undefined"!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},e.t=function(t,n){if(1&n&&(t=e(t)),8&n)return t;if(4&n&&"object"==typeof t&&t&&t.__esModule)return t;var o=Object.create(null);if(e.r(o),Object.defineProperty(o,"default",{enumerable:!0,value:t}),2&n&&"string"!=typeof t)for(var i in t)e.d(o,i,function(n){return t[n]}.bind(null,i));return o},e.n=function(t){var n=t&&t.__esModule?function(){return t.default}:function(){return t};return e.d(n,"a",n),n},e.o=function(t,n){return Object.prototype.hasOwnProperty.call(t,n)},e.p="",e(e.s=223)}({1:function(t,n){t.exports=window.jQuery},2:function(t,n){t.exports=window["$.fn.dataTable"]},223:function(t,n,e){"use strict";e.r(n);e(224)},224:function(t,n,e){var o,i;
/*!
 * Column visibility buttons for Buttons and DataTables.
 * 2016 SpryMedia Ltd - datatables.net/license
 */o=[e(1),e(2),e(5)],void 0===(i=function(t){return function(t,n,e,o){"use strict";var i=t.fn.dataTable;return t.extend(i.ext.buttons,{colvis:function(t,n){return{extend:"collection",text:function(t){return t.i18n("buttons.colvis","Column visibility")},className:"buttons-colvis",buttons:[{extend:"columnsToggle",columns:n.columns,columnText:n.columnText}]}},columnsToggle:function(t,n){return t.columns(n.columns).indexes().map((function(t){return{extend:"columnToggle",columns:t,columnText:n.columnText}})).toArray()},columnToggle:function(t,n){return{extend:"columnVisibility",columns:n.columns,columnText:n.columnText}},columnsVisibility:function(t,n){return t.columns(n.columns).indexes().map((function(t){return{extend:"columnVisibility",columns:t,visibility:n.visibility,columnText:n.columnText}})).toArray()},columnVisibility:{columns:o,text:function(t,n,e){return e._columnText(t,e)},className:"buttons-columnVisibility",action:function(t,n,e,i){var s=n.columns(i.columns),r=s.visible();s.visible(i.visibility!==o?i.visibility:!(r.length&&r[0]))},init:function(t,n,e){var o=this;n.attr("data-cv-idx",e.columns),t.on("column-visibility.dt"+e.namespace,(function(n,i){i.bDestroying||i.nTable!=t.settings()[0].nTable||o.active(t.column(e.columns).visible())})).on("column-reorder.dt"+e.namespace,(function(n,i,s){1===t.columns(e.columns).count()&&(o.text(e._columnText(t,e)),o.active(t.column(e.columns).visible()))})),this.active(t.column(e.columns).visible())},destroy:function(t,n,e){t.off("column-visibility.dt"+e.namespace).off("column-reorder.dt"+e.namespace)},_columnText:function(t,n){var e=t.column(n.columns).index(),o=t.settings()[0].aoColumns[e].sTitle;return o||(o=t.column(e).header().innerHTML),o=o.replace(/\n/g," ").replace(/<br\s*\/?>/gi," ").replace(/<select(.*?)<\/select>/g,"").replace(/<!\-\-.*?\-\->/g,"").replace(/<.*?>/g,"").replace(/^\s+|\s+$/g,""),n.columnText?n.columnText(t,e,o):o}},colvisRestore:{className:"buttons-colvisRestore",text:function(t){return t.i18n("buttons.colvisRestore","Restore visibility")},init:function(t,n,e){e._visOriginal=t.columns().indexes().map((function(n){return t.column(n).visible()})).toArray()},action:function(t,n,e,o){n.columns().every((function(t){var e=n.colReorder&&n.colReorder.transpose?n.colReorder.transpose(t,"toOriginal"):t;this.visible(o._visOriginal[e])}))}},colvisGroup:{className:"buttons-colvisGroup",action:function(t,n,e,o){n.columns(o.show).visible(!0,!1),n.columns(o.hide).visible(!1,!1),n.columns.adjust()},show:[],hide:[]}}),i.Buttons}(t,window,document)}.apply(n,o))||(t.exports=i)},5:function(t,n,e){var o,i;
/*! Buttons for DataTables 1.7.1
 * ©2016-2021 SpryMedia Ltd - datatables.net/license
 */o=[e(1),e(2)],void 0===(i=function(t){return function(t,n,e,o){"use strict";var i=t.fn.dataTable,s=0,r=0,a=i.ext.buttons;function u(n,e,o){t.fn.animate?n.stop().fadeIn(e,o):(n.css("display","block"),o&&o.call(n))}function l(n,e,o){t.fn.animate?n.stop().fadeOut(e,o):(n.css("display","none"),o&&o.call(n))}var c,d=function(n,e){if(!(this instanceof d))return function(t){return new d(t,n).container()};void 0===e&&(e={}),!0===e&&(e={}),Array.isArray(e)&&(e={buttons:e}),this.c=t.extend(!0,{},d.defaults,e),e.buttons&&(this.c.buttons=e.buttons),this.s={dt:new i.Api(n),buttons:[],listenKeys:"",namespace:"dtb"+s++},this.dom={container:t("<"+this.c.dom.container.tag+"/>").addClass(this.c.dom.container.className)},this._constructor()};t.extend(d.prototype,{action:function(t,n){var e=this._nodeToButton(t);return n===o?e.conf.action:(e.conf.action=n,this)},active:function(n,e){var i=this._nodeToButton(n),s=this.c.dom.button.active,r=t(i.node);return e===o?r.hasClass(s):(r.toggleClass(s,e===o||e),this)},add:function(t,n){var e=this.s.buttons;if("string"==typeof n){for(var i=n.split("-"),s=this.s,r=0,a=i.length-1;r<a;r++)s=s.buttons[1*i[r]];e=s.buttons,n=1*i[i.length-1]}return this._expandButton(e,t,s!==o,n),this._draw(),this},container:function(){return this.dom.container},disable:function(n){var e=this._nodeToButton(n);return t(e.node).addClass(this.c.dom.button.disabled).attr("disabled",!0),this},destroy:function(){t("body").off("keyup."+this.s.namespace);var n,e,o=this.s.buttons.slice();for(n=0,e=o.length;n<e;n++)this.remove(o[n].node);this.dom.container.remove();var i=this.s.dt.settings()[0];for(n=0,e=i.length;n<e;n++)if(i.inst===this){i.splice(n,1);break}return this},enable:function(n,e){if(!1===e)return this.disable(n);var o=this._nodeToButton(n);return t(o.node).removeClass(this.c.dom.button.disabled).removeAttr("disabled"),this},name:function(){return this.c.name},node:function(n){if(!n)return this.dom.container;var e=this._nodeToButton(n);return t(e.node)},processing:function(n,e){var i=this.s.dt,s=this._nodeToButton(n);return e===o?t(s.node).hasClass("processing"):(t(s.node).toggleClass("processing",e),t(i.table().node()).triggerHandler("buttons-processing.dt",[e,i.button(n),i,t(n),s.conf]),this)},remove:function(n){var e=this._nodeToButton(n),o=this._nodeToHost(n),i=this.s.dt;if(e.buttons.length)for(var s=e.buttons.length-1;s>=0;s--)this.remove(e.buttons[s].node);e.conf.destroy&&e.conf.destroy.call(i.button(n),i,t(n),e.conf),this._removeKey(e.conf),t(e.node).remove();var r=t.inArray(e,o);return o.splice(r,1),this},text:function(n,e){var i=this._nodeToButton(n),s=this.c.dom.collection.buttonLiner,r=i.inCollection&&s&&s.tag?s.tag:this.c.dom.buttonLiner.tag,a=this.s.dt,u=t(i.node),l=function(t){return"function"==typeof t?t(a,u,i.conf):t};return e===o?l(i.conf.text):(i.conf.text=e,r?u.children(r).html(l(e)):u.html(l(e)),this)},_constructor:function(){var n=this,o=this.s.dt,i=o.settings()[0],s=this.c.buttons;i._buttons||(i._buttons=[]),i._buttons.push({inst:this,name:this.c.name});for(var r=0,a=s.length;r<a;r++)this.add(s[r]);o.on("destroy",(function(t,e){e===i&&n.destroy()})),t("body").on("keyup."+this.s.namespace,(function(t){if(!e.activeElement||e.activeElement===e.body){var o=String.fromCharCode(t.keyCode).toLowerCase();-1!==n.s.listenKeys.toLowerCase().indexOf(o)&&n._keypress(o,t)}}))},_addKey:function(n){n.key&&(this.s.listenKeys+=t.isPlainObject(n.key)?n.key.key:n.key)},_draw:function(t,n){t||(t=this.dom.container,n=this.s.buttons),t.children().detach();for(var e=0,o=n.length;e<o;e++)t.append(n[e].inserter),t.append(" "),n[e].buttons&&n[e].buttons.length&&this._draw(n[e].collection,n[e].buttons)},_expandButton:function(n,e,i,s){for(var r=this.s.dt,a=Array.isArray(e)?e:[e],u=0,l=a.length;u<l;u++){var c=this._resolveExtends(a[u]);if(c)if(Array.isArray(c))this._expandButton(n,c,i,s);else{var d=this._buildButton(c,i);d&&(s!==o&&null!==s?(n.splice(s,0,d),s++):n.push(d),d.conf.buttons&&(d.collection=t("<"+this.c.dom.collection.tag+"/>"),d.conf._collection=d.collection,this._expandButton(d.buttons,d.conf.buttons,!0,s)),c.init&&c.init.call(r.button(d.node),r,t(d.node),c))}}},_buildButton:function(n,e){var i=this.c.dom.button,s=this.c.dom.buttonLiner,a=this.c.dom.collection,u=this.s.dt,l=function(t){return"function"==typeof t?t(u,b,n):t};if(e&&a.button&&(i=a.button),e&&a.buttonLiner&&(s=a.buttonLiner),n.available&&!n.available(u,n))return!1;var c=function(n,e,o,i){i.action.call(e.button(o),n,e,o,i),t(e.table().node()).triggerHandler("buttons-action.dt",[e.button(o),e,o,i])},d=n.tag||i.tag,f=n.clickBlurs===o||n.clickBlurs,b=t("<"+d+"/>").addClass(i.className).attr("tabindex",this.s.dt.settings()[0].iTabIndex).attr("aria-controls",this.s.dt.table().node().id).on("click.dtb",(function(t){t.preventDefault(),!b.hasClass(i.disabled)&&n.action&&c(t,u,b,n),f&&b.trigger("blur")})).on("keyup.dtb",(function(t){13===t.keyCode&&!b.hasClass(i.disabled)&&n.action&&c(t,u,b,n)}));if("a"===d.toLowerCase()&&b.attr("href","#"),"button"===d.toLowerCase()&&b.attr("type","button"),s.tag){var p=t("<"+s.tag+"/>").html(l(n.text)).addClass(s.className);"a"===s.tag.toLowerCase()&&p.attr("href","#"),b.append(p)}else b.html(l(n.text));!1===n.enabled&&b.addClass(i.disabled),n.className&&b.addClass(n.className),n.titleAttr&&b.attr("title",l(n.titleAttr)),n.attr&&b.attr(n.attr),n.namespace||(n.namespace=".dt-button-"+r++);var h,m=this.c.dom.buttonContainer;return h=m&&m.tag?t("<"+m.tag+"/>").addClass(m.className).append(b):b,this._addKey(n),this.c.buttonCreated&&(h=this.c.buttonCreated(n,h)),{conf:n,node:b.get(0),inserter:h,buttons:[],inCollection:e,collection:null}},_nodeToButton:function(t,n){n||(n=this.s.buttons);for(var e=0,o=n.length;e<o;e++){if(n[e].node===t)return n[e];if(n[e].buttons.length){var i=this._nodeToButton(t,n[e].buttons);if(i)return i}}},_nodeToHost:function(t,n){n||(n=this.s.buttons);for(var e=0,o=n.length;e<o;e++){if(n[e].node===t)return n;if(n[e].buttons.length){var i=this._nodeToHost(t,n[e].buttons);if(i)return i}}},_keypress:function(n,e){if(!e._buttonsHandled){var o=function(o,i){if(o.key)if(o.key===n)e._buttonsHandled=!0,t(i).click();else if(t.isPlainObject(o.key)){if(o.key.key!==n)return;if(o.key.shiftKey&&!e.shiftKey)return;if(o.key.altKey&&!e.altKey)return;if(o.key.ctrlKey&&!e.ctrlKey)return;if(o.key.metaKey&&!e.metaKey)return;e._buttonsHandled=!0,t(i).click()}},i=function(t){for(var n=0,e=t.length;n<e;n++)o(t[n].conf,t[n].node),t[n].buttons.length&&i(t[n].buttons)};i(this.s.buttons)}},_removeKey:function(n){if(n.key){var e=t.isPlainObject(n.key)?n.key.key:n.key,o=this.s.listenKeys.split(""),i=t.inArray(e,o);o.splice(i,1),this.s.listenKeys=o.join("")}},_resolveExtends:function(n){var e,i,s=this.s.dt,r=function(e){for(var i=0;!t.isPlainObject(e)&&!Array.isArray(e);){if(e===o)return;if("function"==typeof e){if(!(e=e(s,n)))return!1}else if("string"==typeof e){if(!a[e])throw"Unknown button type: "+e;e=a[e]}if(++i>30)throw"Buttons: Too many iterations"}return Array.isArray(e)?e:t.extend({},e)};for(n=r(n);n&&n.extend;){if(!a[n.extend])throw"Cannot extend unknown button type: "+n.extend;var u=r(a[n.extend]);if(Array.isArray(u))return u;if(!u)return!1;var l=u.className;n=t.extend({},u,n),l&&n.className!==l&&(n.className=l+" "+n.className);var c=n.postfixButtons;if(c){for(n.buttons||(n.buttons=[]),e=0,i=c.length;e<i;e++)n.buttons.push(c[e]);n.postfixButtons=null}var d=n.prefixButtons;if(d){for(n.buttons||(n.buttons=[]),e=0,i=d.length;e<i;e++)n.buttons.splice(e,0,d[e]);n.prefixButtons=null}n.extend=u.extend}return n},_popover:function(o,i,s){var r=i,a=this.c,c=t.extend({align:"button-left",autoClose:!1,background:!0,backgroundClassName:"dt-button-background",contentClassName:a.dom.collection.className,collectionLayout:"",collectionTitle:"",dropup:!1,fade:400,rightAlignClassName:"dt-button-right",tag:a.dom.collection.tag},s),f=i.node(),b=function(){l(t(".dt-button-collection"),c.fade,(function(){t(this).detach()})),t(r.buttons('[aria-haspopup="true"][aria-expanded="true"]').nodes()).attr("aria-expanded","false"),t("div.dt-button-background").off("click.dtb-collection"),d.background(!1,c.backgroundClassName,c.fade,f),t("body").off(".dtb-collection"),r.off("buttons-action.b-internal")};!1===o&&b();var p=t(r.buttons('[aria-haspopup="true"][aria-expanded="true"]').nodes());p.length&&(f=p.eq(0),b());var h=t("<div/>").addClass("dt-button-collection").addClass(c.collectionLayout).css("display","none");o=t(o).addClass(c.contentClassName).attr("role","menu").appendTo(h),f.attr("aria-expanded","true"),f.parents("body")[0]!==e.body&&(f=e.body.lastChild),c.collectionTitle&&h.prepend('<div class="dt-button-collection-title">'+c.collectionTitle+"</div>"),u(h.insertAfter(f),c.fade);var m=t(i.table().container()),g=h.css("position");if("dt-container"===c.align&&(f=f.parent(),h.css("width",m.width())),"absolute"===g){var v=f.position(),y=t(i.node()).position();h.css({top:y.top+f.outerHeight(),left:v.left});var x=h.outerHeight(),_=m.offset().top+m.height(),A=y.top+f.outerHeight()+x-_,T=y.top-x,k=m.offset().top,C=k-T,w=y.top-x-5;(A>C||c.dropup)&&-w<k&&h.css("top",w);var N=m.offset().left,B=N+m.width(),H=h.offset().left,O=H+h.width(),L=f.offset().left,S=L+f.outerWidth();if(h.hasClass(c.rightAlignClassName)||h.hasClass(c.leftAlignClassName)||"dt-container"===c.align){var P,K,j=0;h.hasClass(c.rightAlignClassName)?N>H+(j=S-O)&&(j+=(P=N-(H+j))>(K=B-(O+j))?K:P):B<O+(j=N-H)&&(j+=(P=N-(H+j))>(K=B-(O+j))?K:P),h.css("left",h.position().left+j)}else{var D=f.offset().top;j=0,j="button-right"===c.align?S-O:L-H,h.css("left",h.position().left+j)}}else(D=h.height()/2)>t(n).height()/2&&(D=t(n).height()/2),h.css("marginTop",-1*D);c.background&&d.background(!0,c.backgroundClassName,c.fade,f),t("div.dt-button-background").on("click.dtb-collection",(function(){})),t("body").on("click.dtb-collection",(function(n){var e=t.fn.addBack?"addBack":"andSelf",i=t(n.target).parent()[0];(!t(n.target).parents()[e]().filter(o).length&&!t(i).hasClass("dt-buttons")||t(n.target).hasClass("dt-button-background"))&&b()})).on("keyup.dtb-collection",(function(t){27===t.keyCode&&b()})),c.autoClose&&setTimeout((function(){r.on("buttons-action.b-internal",(function(t,n,e,o){o[0]!==f[0]&&b()}))}),0),t(h).trigger("buttons-popover.dt")}}),d.background=function(n,i,s,r){s===o&&(s=400),r||(r=e.body),n?u(t("<div/>").addClass(i).css("display","none").insertAfter(r),s):l(t("div."+i),s,(function(){t(this).removeClass(i).remove()}))},d.instanceSelector=function(n,e){if(n===o||null===n)return t.map(e,(function(t){return t.inst}));var i=[],s=t.map(e,(function(t){return t.name})),r=function(n){if(Array.isArray(n))for(var o=0,a=n.length;o<a;o++)r(n[o]);else if("string"==typeof n)if(-1!==n.indexOf(","))r(n.split(","));else{var u=t.inArray(n.trim(),s);-1!==u&&i.push(e[u].inst)}else"number"==typeof n&&i.push(e[n].inst)};return r(n),i},d.buttonSelector=function(n,e){for(var i=[],s=function(t,n,e){for(var i,r,a=0,u=n.length;a<u;a++)(i=n[a])&&(r=e!==o?e+a:a+"",t.push({node:i.node,name:i.conf.name,idx:r}),i.buttons&&s(t,i.buttons,r+"-"))},r=function(n,e){var a,u,l=[];s(l,e.s.buttons);var c=t.map(l,(function(t){return t.node}));if(Array.isArray(n)||n instanceof t)for(a=0,u=n.length;a<u;a++)r(n[a],e);else if(null===n||n===o||"*"===n)for(a=0,u=l.length;a<u;a++)i.push({inst:e,node:l[a].node});else if("number"==typeof n)i.push({inst:e,node:e.s.buttons[n].node});else if("string"==typeof n)if(-1!==n.indexOf(",")){var d=n.split(",");for(a=0,u=d.length;a<u;a++)r(d[a].trim(),e)}else if(n.match(/^\d+(\-\d+)*$/)){var f=t.map(l,(function(t){return t.idx}));i.push({inst:e,node:l[t.inArray(n,f)].node})}else if(-1!==n.indexOf(":name")){var b=n.replace(":name","");for(a=0,u=l.length;a<u;a++)l[a].name===b&&i.push({inst:e,node:l[a].node})}else t(c).filter(n).each((function(){i.push({inst:e,node:this})}));else if("object"==typeof n&&n.nodeName){var p=t.inArray(n,c);-1!==p&&i.push({inst:e,node:c[p]})}},a=0,u=n.length;a<u;a++){var l=n[a];r(e,l)}return i},d.stripData=function(t,n){return"string"!=typeof t||(t=(t=t.replace(/<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi,"")).replace(/<!\-\-.*?\-\->/g,""),n&&!n.stripHtml||(t=t.replace(/<[^>]*>/g,"")),n&&!n.trim||(t=t.replace(/^\s+|\s+$/g,"")),n&&!n.stripNewlines||(t=t.replace(/\n/g," ")),n&&!n.decodeEntities||(m.innerHTML=t,t=m.value)),t},d.defaults={buttons:["copy","excel","csv","pdf","print"],name:"main",tabIndex:0,dom:{container:{tag:"div",className:"dt-buttons"},collection:{tag:"div",className:""},button:{tag:"button",className:"dt-button",active:"active",disabled:"disabled"},buttonLiner:{tag:"span",className:""}}},d.version="1.7.1",t.extend(a,{collection:{text:function(t){return t.i18n("buttons.collection","Collection")},className:"buttons-collection",init:function(t,n,e){n.attr("aria-expanded",!1)},action:function(t,n,e,o){t.stopPropagation(),o._collection.parents("body").length?this.popover(!1,o):this.popover(o._collection,o)},attr:{"aria-haspopup":!0}},copy:function(t,n){if(a.copyHtml5)return"copyHtml5"},csv:function(t,n){if(a.csvHtml5&&a.csvHtml5.available(t,n))return"csvHtml5"},excel:function(t,n){if(a.excelHtml5&&a.excelHtml5.available(t,n))return"excelHtml5"},pdf:function(t,n){if(a.pdfHtml5&&a.pdfHtml5.available(t,n))return"pdfHtml5"},pageLength:function(n){var e=n.settings()[0].aLengthMenu,o=[],i=[];if(Array.isArray(e[0]))o=e[0],i=e[1];else for(var s=0;s<e.length;s++){var r=e[s];t.isPlainObject(r)?(o.push(r.value),i.push(r.div)):(o.push(r),i.push(r))}return{extend:"collection",text:function(t){return t.i18n("buttons.pageLength",{"-1":"Show all rows",_:"Show %d rows"},t.page.len())},className:"buttons-page-length",autoClose:!0,buttons:t.map(o,(function(t,n){return{text:i[n],className:"button-page-length",action:function(n,e){e.page.len(t).draw()},init:function(n,e,o){var i=this,s=function(){i.active(n.page.len()===t)};n.on("length.dt"+o.namespace,s),s()},destroy:function(t,n,e){t.off("length.dt"+e.namespace)}}})),init:function(t,n,e){var o=this;t.on("length.dt"+e.namespace,(function(){o.text(e.text)}))},destroy:function(t,n,e){t.off("length.dt"+e.namespace)}}}}),i.Api.register("buttons()",(function(t,n){n===o&&(n=t,t=o),this.selector.buttonGroup=t;var e=this.iterator(!0,"table",(function(e){if(e._buttons)return d.buttonSelector(d.instanceSelector(t,e._buttons),n)}),!0);return e._groupSelector=t,e})),i.Api.register("button()",(function(t,n){var e=this.buttons(t,n);return e.length>1&&e.splice(1,e.length),e})),i.Api.registerPlural("buttons().active()","button().active()",(function(t){return t===o?this.map((function(t){return t.inst.active(t.node)})):this.each((function(n){n.inst.active(n.node,t)}))})),i.Api.registerPlural("buttons().action()","button().action()",(function(t){return t===o?this.map((function(t){return t.inst.action(t.node)})):this.each((function(n){n.inst.action(n.node,t)}))})),i.Api.register(["buttons().enable()","button().enable()"],(function(t){return this.each((function(n){n.inst.enable(n.node,t)}))})),i.Api.register(["buttons().disable()","button().disable()"],(function(){return this.each((function(t){t.inst.disable(t.node)}))})),i.Api.registerPlural("buttons().nodes()","button().node()",(function(){var n=t();return t(this.each((function(t){n=n.add(t.inst.node(t.node))}))),n})),i.Api.registerPlural("buttons().processing()","button().processing()",(function(t){return t===o?this.map((function(t){return t.inst.processing(t.node)})):this.each((function(n){n.inst.processing(n.node,t)}))})),i.Api.registerPlural("buttons().text()","button().text()",(function(t){return t===o?this.map((function(t){return t.inst.text(t.node)})):this.each((function(n){n.inst.text(n.node,t)}))})),i.Api.registerPlural("buttons().trigger()","button().trigger()",(function(){return this.each((function(t){t.inst.node(t.node).trigger("click")}))})),i.Api.register("button().popover()",(function(t,n){return this.map((function(e){return e.inst._popover(t,this.button(this[0].node),n)}))})),i.Api.register("buttons().containers()",(function(){var n=t(),e=this._groupSelector;return this.iterator(!0,"table",(function(t){if(t._buttons)for(var o=d.instanceSelector(e,t._buttons),i=0,s=o.length;i<s;i++)n=n.add(o[i].container())})),n})),i.Api.register("buttons().container()",(function(){return this.containers().eq(0)})),i.Api.register("button().add()",(function(t,n){var e=this.context;if(e.length){var o=d.instanceSelector(this._groupSelector,e[0]._buttons);o.length&&o[0].add(n,t)}return this.button(this._groupSelector,t)})),i.Api.register("buttons().destroy()",(function(){return this.pluck("inst").unique().each((function(t){t.destroy()})),this})),i.Api.registerPlural("buttons().remove()","buttons().remove()",(function(){return this.each((function(t){t.inst.remove(t.node)})),this})),i.Api.register("buttons.info()",(function(n,e,i){var s=this;return!1===n?(this.off("destroy.btn-info"),l(t("#datatables_buttons_info"),400,(function(){t(this).remove()})),clearTimeout(c),c=null,this):(c&&clearTimeout(c),t("#datatables_buttons_info").length&&t("#datatables_buttons_info").remove(),n=n?"<h2>"+n+"</h2>":"",u(t('<div id="datatables_buttons_info" class="dt-button-info"/>').html(n).append(t("<div/>")["string"==typeof e?"html":"append"](e)).css("display","none").appendTo("body")),i!==o&&0!==i&&(c=setTimeout((function(){s.buttons.info(!1)}),i)),this.on("destroy.btn-info",(function(){s.buttons.info(!1)})),this)})),i.Api.register("buttons.exportData()",(function(t){if(this.context.length)return g(new i.Api(this.context[0]),t)})),i.Api.register("buttons.exportInfo()",(function(t){return t||(t={}),{filename:f(t),title:p(t),messageTop:h(this,t.message||t.messageTop,"top"),messageBottom:h(this,t.messageBottom,"bottom")}}));var f=function(n){var e="*"===n.filename&&"*"!==n.title&&n.title!==o&&null!==n.title&&""!==n.title?n.title:n.filename;if("function"==typeof e&&(e=e()),e===o||null===e)return null;-1!==e.indexOf("*")&&(e=e.replace("*",t("head > title").text()).trim()),e=e.replace(/[^a-zA-Z0-9_\u00A1-\uFFFF\.,\-_ !\(\)]/g,"");var i=b(n.extension);return i||(i=""),e+i},b=function(t){return null===t||t===o?null:"function"==typeof t?t():t},p=function(n){var e=b(n.title);return null===e?null:-1!==e.indexOf("*")?e.replace("*",t("head > title").text()||"Exported data"):e},h=function(n,e,o){var i=b(e);if(null===i)return null;var s=t("caption",n.table().container()).eq(0);return"*"===i?s.css("caption-side")!==o?null:s.length?s.text():"":i},m=t("<textarea/>")[0],g=function(n,e){var i=t.extend(!0,{},{rows:null,columns:"",modifier:{search:"applied",order:"applied"},orthogonal:"display",stripHtml:!0,stripNewlines:!0,decodeEntities:!0,trim:!0,format:{header:function(t){return d.stripData(t,i)},footer:function(t){return d.stripData(t,i)},body:function(t){return d.stripData(t,i)}},customizeData:null},e),s=n.columns(i.columns).indexes().map((function(t){var e=n.column(t).header();return i.format.header(e.innerHTML,t,e)})).toArray(),r=n.table().footer()?n.columns(i.columns).indexes().map((function(t){var e=n.column(t).footer();return i.format.footer(e?e.innerHTML:"",t,e)})).toArray():null,a=t.extend({},i.modifier);n.select&&"function"==typeof n.select.info&&a.selected===o&&n.rows(i.rows,t.extend({selected:!0},a)).any()&&t.extend(a,{selected:!0});for(var u=n.rows(i.rows,a).indexes().toArray(),l=n.cells(u,i.columns),c=l.render(i.orthogonal).toArray(),f=l.nodes().toArray(),b=s.length,p=[],h=0,m=0,g=b>0?c.length/b:0;m<g;m++){for(var v=[b],y=0;y<b;y++)v[y]=i.format.body(c[h],m,y,f[h]),h++;p[m]=v}var x={header:s,footer:r,body:p};return i.customizeData&&i.customizeData(x),x};function v(t,n){var e=new i.Api(t),o=n||e.init().buttons||i.defaults.buttons;return new d(e,o).container()}return t.fn.dataTable.Buttons=d,t.fn.DataTable.Buttons=d,t(e).on("init.dt plugin-init.dt",(function(t,n){if("dt"===t.namespace){var e=n.oInit.buttons||i.defaults.buttons;e&&!n._buttons&&new d(n,e).container()}})),i.ext.feature.push({fnInit:v,cFeature:"B"}),i.ext.features&&i.ext.features.register("buttons",v),d}(t,window,document)}.apply(n,o))||(t.exports=i)}}));