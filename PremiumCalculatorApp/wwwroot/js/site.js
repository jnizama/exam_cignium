// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//NOTE: Auxiliar AJAX callback func
function execAsyncAjax(Url, postData, funcAction, dataType)
{
    $.ajax( {
      type: "POST",
      data: postData,
      dataType: dataType,
      //async: true, //cAMBIA ESTO SI ALGO NO FUNCIONA Y/O PARAMETRIZARLO
      //traditional: true,
      url: Url,
      success: funcAction
    }).fail( function ( data ) {
      if ( window.console && window.console.log ) {
        console.log( data );
      }
    });
}
function execAsyncAjaxErr(Url, postData, funcSuccess, funcFail, dataType)
  {
    $.ajax( {
      type: "POST",
      data: postData,
      dataType: dataType,
      url: Url,
      success: funcSuccess
    }).fail(funcFail);
  }