<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unauthorizedPage.aspx.cs" Inherits="OIPD.unauthorizedPage" %>

<!DOCTYPE html>
<html>
<head>
<title>Unauthorized Page</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link href="https://www.w3schools.com/w3css/4/w3.css" rel="Stylesheet" />
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lato"/>
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat"/>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
<style type="text/css">
body,h1,h2,h3,h4,h5,h6 {font-family: "Lato", sans-serif}
.w3-bar,h1,button {font-family: "Montserrat", sans-serif}
.fa-anchor,.fa-coffee {font-size:200px}
</style>


</head>
<body background="Resources/unauthorized.jpg">

<div class="w3-container w3-center w3-text-white" style="padding:128px 16px">
  <h1 class="w3-margin w3-jumbo">UNAUTHORIZED ACCESS</h1>
  <p class="w3-xlarge"><b>!!! Sorry !!!</b><br/>You Are Not Authorized To View This Page</p>
 <button class="w3-button w3-black w3-padding-large w3-large w3-margin-top" onclick="go_Back()"><b>Back</b></button>
</div>

<script type="text/javascript">
    function go_Back() {
        window.history.back()
    }
</script>

</body>
</html>
