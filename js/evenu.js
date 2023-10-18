//Hide menu

 function toggleSpam(togDivId)
 {
      var state = document.getElementById(togDivId).style.display;
      if (state == 'block') 
      {
            document.getElementById(togDivId).style.display = 'none';
      }
      else 
      {
            document.getElementById(togDivId).style.display = 'block';
      }
 }