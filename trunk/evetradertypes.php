<?php

//yes, this is evil and dirty, but it's the fastest way to generate these xmls.
$host = "localhost";
$login = "";
$pw = "";
$db = "";

function cut($input)
{
	$out = preg_replace("([\r\n]+)", "", $input);
	$out = str_replace("&", "&#".ord("&").";", $out);
	$out = str_replace("<br>", "", $out);
	$out = str_replace("<i>", "", $out);
	$out = str_replace("</i>", "", $out);
	$out = str_replace("<", "&#".ord("<").";", $out);
	$out = str_replace(">", "&#".ord(">").";", $out);
	$out = str_replace("'", "&#".ord("'").";", $out);
	
	return $out;
}

mysql_connect("localhost", $login, $pw);
mysql_select_db($db);

$sql = "Select typeID, typeName, description from invtypes";
$qry = mysql_query($sql);

$output = "<Types>\r\n";

while($out = mysql_fetch_object($qry))
{
	//<Type><Id>0</Id><Name>#System</Name><Description></Description></Type>
	$output .= "<Type><Id>".$out->typeID."</Id><Name>".cut($out->typeName)."</Name><Description>".cut($out->description)."</Description></Type>\r\n";
}

$output .="</Types>";

$handle = fopen("EveTypes.xml", "w+");

fwrite($handle, $output);

fclose($handle);

?>