$uris = @(
 "http://localhost:61880/api/log-log",
 "http://localhost:61880/api/log-a"
)

function Randomize-List
{
   Param(
     [array]$InputList
   )

   return $InputList | Sort-Object {Get-Random}
}

for($i=1;$i -le 5000;$i++) {
    sleep -m 100
    foreach($uri in (Randomize-List -InputList $uris)){
        curl $uri
    }
}
