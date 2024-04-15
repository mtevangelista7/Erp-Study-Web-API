ë
lC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Utilities\Util.cs
	namespace 	
ErpStudyWebAPI
 
. 
	Utilities "
{ 
public 

class 
Util 
{ 
public 
static 
string 
StringConexao *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
}		 ·"
eC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Startup.cs
	namespace 	
ErpStudyWebAPI
 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
var 
dbHost 
= 
Environment $
.$ %"
GetEnvironmentVariable% ;
(; <
$str< E
)E F
;F G
var   
dbName   
=   
Environment   $
.  $ %"
GetEnvironmentVariable  % ;
(  ; <
$str  < E
)  E F
;  F G
var!! 
dbUser!! 
=!! 
Environment!! $
.!!$ %"
GetEnvironmentVariable!!% ;
(!!; <
$str!!< E
)!!E F
;!!F G
var"" 

dbPassword"" 
="" 
Environment"" (
.""( )"
GetEnvironmentVariable"") ?
(""? @
$str""@ P
)""P Q
;""Q R
Util$$ 
.$$ 
StringConexao$$ 
=$$  
$"$$! #
$str$$# *
{$$* +
dbHost$$+ 1
}$$1 2
$str$$2 <
{$$< =
dbName$$= C
}$$C D
$str$$D M
{$$M N
dbUser$$N T
}$$T U
$str$$U _
{$$_ `

dbPassword$$` j
}$$j k
$str	$$k ¢
"
$$¢ £
;
$$£ ¤
services&& 
.&& 
AddSwaggerGen&& "
(&&" #
c&&# $
=>&&% '
{'' 
c(( 
.(( 

SwaggerDoc(( 
((( 
$str(( !
,((! "
new((# &
	Microsoft((' 0
.((0 1
OpenApi((1 8
.((8 9
Models((9 ?
.((? @
OpenApiInfo((@ K
{((L M
Title((N S
=((T U
$str((V f
,((f g
Version((h o
=((p q
$str((r v
}((w x
)((x y
;((y z
})) 
))) 
;)) 
}** 	
public-- 
void-- 
	Configure-- 
(-- 
IApplicationBuilder-- 1
app--2 5
,--5 6
IWebHostEnvironment--7 J
env--K N
)--N O
{.. 	
if// 
(// 
env// 
.// 
IsDevelopment// !
(//! "
)//" #
)//# $
{00 
app11 
.11 %
UseDeveloperExceptionPage11 -
(11- .
)11. /
;11/ 0
}22 
app44 
.44 
UseHttpsRedirection44 #
(44# $
)44$ %
;44% &
app66 
.66 

UseRouting66 
(66 
)66 
;66 
app88 
.88 
UseAuthorization88  
(88  !
)88! "
;88" #
app:: 
.:: 
UseEndpoints:: 
(:: 
	endpoints:: &
=>::' )
{;; 
	endpoints<< 
.<< 
MapControllers<< (
(<<( )
)<<) *
;<<* +
}== 
)== 
;== 
app?? 
.?? 

UseSwagger?? 
(?? 
)?? 
;?? 
app@@ 
.@@ 
UseSwaggerUI@@ 
(@@ 
c@@ 
=>@@ !
{AA 
cBB 
.BB 
RoutePrefixBB 
=BB 
stringBB  &
.BB& '
EmptyBB' ,
;BB, -
cCC 
.CC 
SwaggerEndpointCC !
(CC! "
$strCC" <
,CC< =
$strCC> Q
)CCQ R
;CCR S
}DD 
)DD 
;DD 
}EE 	
}FF 
}GG ã
uC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Services\ProdutoService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
{ 
public 

class 
ProdutoService 
{ 
public		 
void		 
AdicionarProduto		 $
(		$ %
Produto		% ,
produto		- 4
)		4 5
{

 	
ProdutoRepository 
produtoRepository /
=0 1
new2 5
ProdutoRepository6 G
(G H
UtilH L
.L M
StringConexaoM Z
)Z [
;[ \
produtoRepository 
. 
InsereProduto +
(+ ,
produto, 3
)3 4
;4 5
} 	
} 
} Ò
wC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Services\CategoriaService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
{		 
public

 

class

 
CategoriaService

 !
{ 
public 
async 
Task 
AdicionarCategoria ,
(, -
	Categoria- 6
	categoria7 @
)@ A
{ 	
CategoriaRepository 
categoriaRepository  3
=4 5
new6 9
CategoriaRepository: M
(M N
UtilN R
.R S
StringConexaoS `
)` a
;a b
await 
categoriaRepository %
.% &
InsereCategoria& 5
(5 6
	categoria6 ?
)? @
;@ A
} 	
public 
async 
Task 
< 
	Categoria #
># $
RetornaCategoria% 5
(5 6
Guid6 :
guidId; A
)A B
{ 	
CategoriaRepository 
categoriaRepository  3
=4 5
new6 9
CategoriaRepository: M
(M N
UtilN R
.R S
StringConexaoS `
)` a
;a b
return 
await 
categoriaRepository ,
., -
RetornaCategoria- =
(= >
guidId> D
)D E
;E F
} 	
public 
async 
Task 
< 
List 
< 
	Categoria (
>( )
>) *
RetornaCategorias+ <
(< =
)= >
{ 	
CategoriaRepository 
categoriaRepository  3
=4 5
new6 9
CategoriaRepository: M
(M N
UtilN R
.R S
StringConexaoS `
)` a
;a b
return 
await 
categoriaRepository ,
., -
RetornaCategorias- >
(> ?
)? @
;@ A
} 	
public!! 
async!! 
Task!! 
AtualizarCategoria!! ,
(!!, -
	Categoria!!- 6
	categoria!!7 @
)!!@ A
{"" 	
CategoriaRepository## 
categoriaRepository##  3
=##4 5
new##6 9
CategoriaRepository##: M
(##M N
Util##N R
.##R S
StringConexao##S `
)##` a
;##a b
await%% 
categoriaRepository%% %
.%%% &
AtualizaCategoria%%& 7
(%%7 8
	categoria%%8 A
)%%A B
;%%B C
}&& 	
public(( 
async(( 
Task(( 
DeletarCategoria(( *
(((* +
Guid((+ /
guidId((0 6
)((6 7
{)) 	
CategoriaRepository** 
categoriaRepository**  3
=**4 5
new**6 9
CategoriaRepository**: M
(**M N
Util**N R
.**R S
StringConexao**S `
)**` a
;**a b
await,, 
categoriaRepository,, %
.,,% &
DeletaCategoria,,& 5
(,,5 6
guidId,,6 <
),,< =
;,,= >
}-- 	
}.. 
}// ºG
zC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Repository\ProdutoRepository.cs
	namespace 	
ErpStudyWebAPI
 
. 

Repository #
{		 
public

 

class

 
ProdutoRepository

 "
{ 
private 
readonly 
string 
_connectionString  1
;1 2
public 
ProdutoRepository  
(  !
string! '
connectionString( 8
)8 9
{ 	
_connectionString 
= 
connectionString  0
;0 1
} 	
public 
void 
InsereProduto !
(! "
Produto" )
produto* 1
)1 2
{ 	
StringBuilder 
stringBuilder '
=( )
new* -
StringBuilder. ;
(; <
)< =
;= >
using 
SqlConnection 

connection  *
=+ ,
new- 0
SqlConnection1 >
(> ?
_connectionString? P
)P Q
;Q R

connection 
. 
Open 
( 
) 
; 
stringBuilder 
. 
Append  
(  !
$str! 8
)8 9
;9 :
stringBuilder 
. 
Append  
(  !
$str! &
)& '
;' (
stringBuilder 
. 
Append  
(  !
$str! f
)f g
;g h
stringBuilder 
. 
Append  
(  !
$str! &
)& '
;' (
using 
( 

SqlCommand 
command %
=& '
new( +

SqlCommand, 6
(6 7
stringBuilder7 D
.D E
ToStringE M
(M N
)N O
,O P

connectionQ [
)[ \
)\ ]
{   
command!! 
.!! 

Parameters!! "
.!!" #
AddWithValue!!# /
(!!/ 0
$str!!0 7
,!!7 8
produto!!9 @
.!!@ A
Nome!!A E
)!!E F
;!!F G
command"" 
."" 

Parameters"" "
.""" #
AddWithValue""# /
(""/ 0
$str""0 <
,""< =
produto""> E
.""E F
	CodigoSKU""F O
)""O P
;""P Q
command## 
.## 

Parameters## "
.##" #
AddWithValue### /
(##/ 0
$str##0 =
,##= >
produto##? F
.##F G

PrecoVenda##G Q
)##Q R
;##R S
command$$ 
.$$ 

Parameters$$ "
.$$" #
AddWithValue$$# /
($$/ 0
$str$$0 :
,$$: ;
produto$$< C
.$$C D
Unidade$$D K
)$$K L
;$$L M
command%% 
.%% 

Parameters%% "
.%%" #
AddWithValue%%# /
(%%/ 0
$str%%0 ;
,%%; <
produto%%= D
.%%D E
Condicao%%E M
)%%M N
;%%N O
command&& 
.&& 

Parameters&& "
.&&" #
AddWithValue&&# /
(&&/ 0
$str&&0 >
,&&> ?
produto&&@ G
.&&G H
	Categoria&&H Q
.&&Q R
CategoriaID&&R ]
)&&] ^
;&&^ _
command(( 
.(( 
ExecuteNonQuery(( '
(((' (
)((( )
;(() *
})) 
}** 	
public,, 
List,, 
<,, 
Produto,, 
>,,  
RetornaTodosProdutos,, 1
(,,1 2
),,2 3
{-- 	
using.. 
SqlConnection.. 

connection..  *
=..+ ,
new..- 0
SqlConnection..1 >
(..> ?
_connectionString..? P
)..P Q
;..Q R

connection// 
.// 
Open// 
(// 
)// 
;// 
string11 
sQuery11 
=11 
$str11 x
;11x y
using33 

SqlCommand33 
command33 $
=33% &
new33' *

SqlCommand33+ 5
(335 6
sQuery336 <
,33< =

connection33> H
)33H I
;33I J
using55 
SqlDataReader55 
reader55  &
=55' (
command55) 0
.550 1
ExecuteReader551 >
(55> ?
)55? @
;55@ A
List77 
<77 
Produto77 
>77 
produtos77 "
=77# $
new77% (
List77) -
<77- .
Produto77. 5
>775 6
(776 7
)777 8
;778 9
while99 
(99 
reader99 
.99 
Read99 
(99 
)99  
)99  !
{:: 
Produto;; 
produto;; 
=;;  !
new;;" %
Produto;;& -
{<< 
	ProdutoID== 
=== 
reader==  &
.==& '
GetGuid==' .
(==. /
reader==/ 5
.==5 6

GetOrdinal==6 @
(==@ A
$str==A L
)==L M
)==M N
,==N O
Nome>> 
=>> 
reader>> !
.>>! "
	GetString>>" +
(>>+ ,
reader>>, 2
.>>2 3

GetOrdinal>>3 =
(>>= >
$str>>> D
)>>D E
)>>E F
,>>F G
	CodigoSKU?? 
=?? 
reader??  &
.??& '
	GetString??' 0
(??0 1
reader??1 7
.??7 8

GetOrdinal??8 B
(??B C
$str??C N
)??N O
)??O P
,??P Q

PrecoVenda@@ 
=@@  
reader@@! '
.@@' (
	GetDouble@@( 1
(@@1 2
reader@@2 8
.@@8 9

GetOrdinal@@9 C
(@@C D
$str@@D P
)@@P Q
)@@Q R
,@@R S
UnidadeAA 
=AA 
(AA 
UnidadeAA &
)AA& '
readerAA' -
.AA- .
GetInt32AA. 6
(AA6 7
readerAA7 =
.AA= >

GetOrdinalAA> H
(AAH I
$strAAI R
)AAR S
)AAS T
,AAT U
CondicaoBB 
=BB 
(BB  
CondicaoBB  (
)BB( )
readerBB) /
.BB/ 0
GetInt32BB0 8
(BB8 9
readerBB9 ?
.BB? @

GetOrdinalBB@ J
(BBJ K
$strBBK U
)BBU V
)BBV W
,BBW X
	CategoriaCC 
=CC 
newCC  #
	CategoriaCC$ -
{DD 
CategoriaIDEE #
=EE$ %
readerEE& ,
.EE, -
GetGuidEE- 4
(EE4 5
readerEE5 ;
.EE; <

GetOrdinalEE< F
(EEF G
$strEEG T
)EET U
)EEU V
,EEV W
NomeFF 
=FF 
readerFF %
.FF% &
	GetStringFF& /
(FF/ 0
readerFF0 6
.FF6 7

GetOrdinalFF7 A
(FFA B
$strFFB H
)FFH I
)FFI J
}GG 
}HH 
;HH 
produtosJJ 
.JJ 
AddJJ 
(JJ 
produtoJJ $
)JJ$ %
;JJ% &
}KK 
readerMM 
.MM 
CloseMM 
(MM 
)MM 
;MM 
returnOO 
produtosOO 
;OO 
}PP 	
publicRR 
ProdutoRR 
RetornaProdutoRR %
(RR% &
GuidRR& *
produtoGuidRR+ 6
)RR6 7
{SS 	
usingTT 
SqlConnectionTT 

connectionTT  *
=TT+ ,
newTT- 0
SqlConnectionTT1 >
(TT> ?
_connectionStringTT? P
)TTP Q
;TTQ R
ProdutoUU 
produtoUU 
=UU 
newUU !
ProdutoUU" )
(UU) *
)UU* +
;UU+ ,

connectionVV 
.VV 
OpenVV 
(VV 
)VV 
;VV 
stringXX 
sQueryXX 
=XX 
$strXX Z
;XXZ [
usingZZ 
(ZZ 

SqlCommandZZ 
commandZZ %
=ZZ& '
newZZ( +

SqlCommandZZ, 6
(ZZ6 7
sQueryZZ7 =
,ZZ= >

connectionZZ? I
)ZZI J
)ZZJ K
{[[ 
command\\ 
.\\ 

Parameters\\ "
.\\" #
AddWithValue\\# /
(\\/ 0
$str\\0 <
,\\< =
produtoGuid\\> I
)\\I J
;\\J K
produto^^ 
=^^ 
(^^ 
Produto^^ "
)^^" #
command^^# *
.^^* +
ExecuteScalar^^+ 8
(^^8 9
)^^9 :
;^^: ;
}__ 
returnaa 
produtoaa 
;aa 
}bb 	
}cc 
}dd õA
|C:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Repository\CategoriaRepository.cs
	namespace		 	
ErpStudyWebAPI		
 
.		 

Repository		 #
{

 
public 

class 
CategoriaRepository $
{ 
private 
readonly 
string 
_connectionString  1
;1 2
public 
CategoriaRepository "
(" #
string# )
connectionString* :
): ;
{ 	
_connectionString 
= 
connectionString  0
;0 1
} 	
public 
async 
Task 
InsereCategoria )
() *
	Categoria* 3
	categoria4 =
)= >
{ 	
using 
SqlConnection 

connection  *
=+ ,
new- 0
SqlConnection1 >
(> ?
_connectionString? P
)P Q
;Q R

connection 
. 
Open 
( 
) 
; 
string 
sQuery 
= 
$str K
;K L
using 

SqlCommand 
command $
=% &
new' *

SqlCommand+ 5
(5 6
sQuery6 <
,< =

connection> H
)H I
;I J
command 
. 

Parameters 
. 
AddWithValue +
(+ ,
$str, 3
,3 4
	categoria5 >
.> ?
Nome? C
)C D
;D E
await 
command 
.  
ExecuteNonQueryAsync .
(. /
)/ 0
;0 1
} 	
public   
async   
Task   
AtualizaCategoria   +
(  + ,
	Categoria  , 5
	categoria  6 ?
)  ? @
{!! 	
using"" 
SqlConnection"" 

connection""  *
=""+ ,
new""- 0
SqlConnection""1 >
(""> ?
_connectionString""? P
)""P Q
;""Q R

connection## 
.## 
Open## 
(## 
)## 
;## 
string$$ 
sQuery$$ 
=$$ 
$str$$ b
;$$b c
using%% 

SqlCommand%% 
command%% $
=%%% &
new%%' *

SqlCommand%%+ 5
(%%5 6
sQuery%%6 <
,%%< =

connection%%> H
)%%H I
;%%I J
command'' 
.'' 

Parameters'' 
.'' 
AddWithValue'' +
(''+ ,
$str'', 3
,''3 4
	categoria''5 >
.''> ?
Nome''? C
)''C D
;''D E
command(( 
.(( 

Parameters(( 
.(( 
AddWithValue(( +
(((+ ,
$str((, :
,((: ;
	categoria((< E
.((E F
CategoriaID((F Q
)((Q R
;((R S
await** 
command** 
.**  
ExecuteNonQueryAsync** .
(**. /
)**/ 0
;**0 1
}++ 	
public-- 
async-- 
Task-- 
<-- 
	Categoria-- #
>--# $
RetornaCategoria--% 5
(--5 6
Guid--6 :
guidId--; A
)--A B
{.. 	
if// 
(// 
guidId// 
==// 
Guid// 
.// 
Empty// $
)//$ %
{00 
return11 
null11 
;11 
}22 
using44 
SqlConnection44 

connection44  *
=44+ ,
new44- 0
SqlConnection441 >
(44> ?
_connectionString44? P
)44P Q
;44Q R

connection55 
.55 
Open55 
(55 
)55 
;55 
string66 
sQuery66 
=66 
$str66 X
;66X Y
using77 

SqlCommand77 
command77 $
=77% &
new77' *

SqlCommand77+ 5
(775 6
sQuery776 <
,77< =

connection77> H
)77H I
;77I J
command99 
.99 

Parameters99 
.99 
AddWithValue99 +
(99+ ,
$str99, :
,99: ;
guidId99< B
)99B C
;99C D
	Categoria;; 
	categoria;; 
=;;  !
(;;" #
	Categoria;;# ,
);;, -
await;;- 2
command;;3 :
.;;: ;
ExecuteScalarAsync;;; M
(;;M N
);;N O
;;;O P
return<< 
	categoria<< 
;<< 
}== 	
public?? 
async?? 
Task?? 
<?? 
List?? 
<?? 
	Categoria?? (
>??( )
>??) *
RetornaCategorias??+ <
(??< =
)??= >
{@@ 	
usingAA 
SqlConnectionAA 

connectionAA  *
=AA+ ,
newAA- 0
SqlConnectionAA1 >
(AA> ?
_connectionStringAA? P
)AAP Q
;AAQ R

connectionBB 
.BB 
OpenBB 
(BB 
)BB 
;BB 
stringCC 
sQueryCC 
=CC 
$strCC 7
;CC7 8
usingDD 

SqlCommandDD 
commandDD $
=DD% &
newDD' *

SqlCommandDD+ 5
(DD5 6
sQueryDD6 <
,DD< =

connectionDD> H
)DDH I
;DDI J
usingFF 
SqlDataReaderFF 
readerFF  &
=FF' (
awaitFF) .
commandFF/ 6
.FF6 7
ExecuteReaderAsyncFF7 I
(FFI J
)FFJ K
;FFK L
ListHH 
<HH 
	CategoriaHH 
>HH 
listcategoriasHH *
=HH+ ,
newHH- 0
ListHH1 5
<HH5 6
	CategoriaHH6 ?
>HH? @
(HH@ A
)HHA B
;HHB C
whileJJ 
(JJ 
readerJJ 
.JJ 
ReadJJ 
(JJ 
)JJ  
)JJ  !
{KK 
	CategoriaLL 

categoria1LL $
=LL% &
newLL' *
	CategoriaLL+ 4
{MM 
CategoriaIDNN 
=NN  !
readerNN" (
.NN( )
GetGuidNN) 0
(NN0 1
$strNN1 >
)NN> ?
,NN? @
NomeOO 
=OO 
readerOO !
.OO! "
	GetStringOO" +
(OO+ ,
readerOO, 2
.OO2 3

GetOrdinalOO3 =
(OO= >
$strOO> D
)OOD E
)OOE F
}PP 
;PP 
listcategoriasRR 
.RR 
AddRR "
(RR" #

categoria1RR# -
)RR- .
;RR. /
}SS 
returnUU 
listcategoriasUU !
;UU! "
}VV 	
publicXX 
asyncXX 
TaskXX 
DeletaCategoriaXX )
(XX) *
GuidXX* .
guidIdXX/ 5
)XX5 6
{YY 	
ifZZ 
(ZZ 
guidIdZZ 
==ZZ 
GuidZZ 
.ZZ 
EmptyZZ $
)ZZ$ %
{[[ 
return\\ 
;\\ 
}]] 
using__ 
SqlConnection__ 

connection__  *
=__+ ,
new__- 0
SqlConnection__1 >
(__> ?
_connectionString__? P
)__P Q
;__Q R

connection`` 
.`` 
Open`` 
(`` 
)`` 
;`` 
stringaa 
sQueryaa 
=aa 
$straa U
;aaU V
usingbb 

SqlCommandbb 
commandbb $
=bb% &
newbb' *

SqlCommandbb+ 5
(bb5 6
sQuerybb6 <
,bb< =

connectionbb> H
)bbH I
;bbI J
commanddd 
.dd 

Parametersdd 
.dd 
AddWithValuedd +
(dd+ ,
$strdd, :
,dd: ;
guidIddd< B
)ddB C
;ddC D
awaitff 
commandff 
.ff  
ExecuteNonQueryAsyncff .
(ff. /
)ff/ 0
;ff0 1
}gg 	
}hh 
}ii Á

eC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Program.cs
	namespace

 	
ErpStudyWebAPI


 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} þ

lC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Models\Produto.cs
	namespace 	
ErpStudyWebAPI
 
. 
Models 
{ 
public 

class 
Produto 
{ 
public 
Guid 
	ProdutoID 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
string		 
Nome		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
string

 
	CodigoSKU

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
double 

PrecoVenda  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
Unidade 
Unidade 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
Condicao 
Condicao  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
	Categoria 
	Categoria "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} Ý
rC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Models\Enums\Unidade.cs
	namespace 	
ErpStudyWebAPI
 
. 
Models 
.  
Enums  %
{ 
public 

enum 
Unidade 
{ 
UNIDADE 
, 

QUILOGRAMA 
, 
LITRO 
, 
METRO 
}		 
}

 “
sC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Models\Enums\Condicao.cs
	namespace 	
ErpStudyWebAPI
 
. 
Models 
.  
Enums  %
{ 
public 

enum 
Condicao 
{ 
NOVO 
, 
USADO 
} 
} ï
nC:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Models\Categoria.cs
	namespace 	
ErpStudyWebAPI
 
. 
Models 
{ 
public 

class 
	Categoria 
{ 
public 
Guid 
CategoriaID 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Nome 
{ 
get  
;  !
set" %
;% &
}' (
}		 
}

 Ö
{C:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Controllers\ProdutoController.cs
	namespace 	
ErpStudyWebAPI
 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public		 

class		 
ProdutoController		 "
:		# $
ControllerBase		% 3
{

 
private 
readonly 
ILogger  
<  !
ProdutoController! 2
>2 3
_logger4 ;
;; <
public 
ProdutoController  
(  !
ILogger! (
<( )
ProdutoController) :
>: ;
logger< B
)B C
{ 	
_logger 
= 
logger 
; 
} 	
} 
} ÐC
}C:\Users\p-mesantos\Downloads\Erp-Study-Web-API-main\Erp-Study-Web-API-main\ErpStudyWebAPI\Controllers\CategoriaController.cs
	namespace

 	
ErpStudyWebAPI


 
.

 
Controllers

 $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
CategoriaController $
:% &
ControllerBase' 5
{ 
private 
readonly 
ILogger  
<  !
CategoriaController! 4
>4 5
_logger6 =
;= >
public 
CategoriaController "
(" #
ILogger# *
<* +
CategoriaController+ >
>> ?
logger@ F
)F G
{ 	
_logger 
= 
logger 
; 
} 	
[ 	
HttpPost	 
( 
$str &
)& '
]' (
public 
async 
Task 
< 
IActionResult '
>' (
AdicionarCategoria) ;
(; <
[< =
FromBody= E
]E F
	CategoriaG P
	categoriaQ Z
)Z [
{ 	
try 
{ 
if 
( 
	categoria 
==  
null! %
)% &
{ 
return 

StatusCode %
(% &
StatusCodes& 1
.1 2
Status400BadRequest2 E
)E F
;F G
}   
CategoriaService""  
categoriaService""! 1
=""2 3
new""4 7
CategoriaService""8 H
(""H I
)""I J
;""J K
await$$ 
categoriaService$$ &
.$$& '
AdicionarCategoria$$' 9
($$9 :
	categoria$$: C
)$$C D
;$$D E
return&& 

StatusCode&& !
(&&! "
StatusCodes&&" -
.&&- .
Status201Created&&. >
)&&> ?
;&&? @
}'' 
catch(( 
((( 
	Exception(( 
ex(( 
)((  
{)) 
_logger** 
.** 
LogError**  
(**  !
ex**! #
,**# $
$str**% ?
)**? @
;**@ A
return++ 

StatusCode++ !
(++! "
StatusCodes++" -
.++- .(
Status500InternalServerError++. J
,++J K
ex++L N
.++N O
Message++O V
)++V W
;++W X
},, 
}-- 	
[// 	
HttpPost//	 
(// 
$str// $
)//$ %
]//% &
public00 
async00 
Task00 
<00 
IActionResult00 '
>00' (
RetornaCategoria00) 9
(009 :
[00: ;
FromBody00; C
]00C D
Guid00E I
guidID00J P
)00P Q
{11 	
try22 
{33 
CategoriaService44  
categoriaService44! 1
=442 3
new444 7
CategoriaService448 H
(44H I
)44I J
;44J K
return66 
Ok66 
(66 
await66 
categoriaService66  0
.660 1
RetornaCategoria661 A
(66A B
guidID66B H
)66H I
)66I J
;66J K
}77 
catch88 
(88 
	Exception88 
ex88 
)88  
{99 
_logger:: 
.:: 
LogError::  
(::  !
ex::! #
,::# $
$str::% >
)::> ?
;::? @
return;; 

StatusCode;; !
(;;! "
StatusCodes;;" -
.;;- .(
Status500InternalServerError;;. J
,;;J K
ex;;L N
.;;N O
Message;;O V
);;V W
;;;W X
}<< 
}== 	
[?? 	
HttpGet??	 
(?? 
$str?? $
)??$ %
]??% &
public@@ 
async@@ 
Task@@ 
<@@ 
IActionResult@@ '
>@@' (
RetornaCategorias@@) :
(@@: ;
)@@; <
{AA 	
tryBB 
{CC 
CategoriaServiceDD  
categoriaServiceDD! 1
=DD2 3
newDD4 7
CategoriaServiceDD8 H
(DDH I
)DDI J
;DDJ K
returnFF 
OkFF 
(FF 
awaitFF 
categoriaServiceFF  0
.FF0 1
RetornaCategoriasFF1 B
(FFB C
)FFC D
)FFD E
;FFE F
}GG 
catchHH 
(HH 
	ExceptionHH 
exHH 
)HH  
{II 
_loggerJJ 
.JJ 
LogErrorJJ  
(JJ  !
exJJ! #
,JJ# $
$strJJ% B
)JJB C
;JJC D
returnKK 

StatusCodeKK !
(KK! "
StatusCodesKK" -
.KK- .(
Status500InternalServerErrorKK. J
,KKJ K
exKKL N
.KKN O
MessageKKO V
)KKV W
;KKW X
}LL 
}MM 	
[OO 	
HttpPutOO	 
(OO 
$strOO $
)OO$ %
]OO% &
publicPP 
asyncPP 
TaskPP 
<PP 
IActionResultPP '
>PP' (
AtualizaCategoriaPP) :
(PP: ;
[PP; <
FromBodyPP< D
]PPD E
	CategoriaPPF O
	categoriaPPP Y
)PPY Z
{QQ 	
tryRR 
{SS 
ifTT 
(TT 
	categoriaTT 
==TT  
nullTT! %
)TT% &
{UU 
returnVV 

StatusCodeVV %
(VV% &
StatusCodesVV& 1
.VV1 2
Status400BadRequestVV2 E
)VVE F
;VVF G
}WW 
CategoriaServiceYY  
categoriaServiceYY! 1
=YY2 3
newYY4 7
CategoriaServiceYY8 H
(YYH I
)YYI J
;YYJ K
await[[ 
categoriaService[[ &
.[[& '
AtualizarCategoria[[' 9
([[9 :
	categoria[[: C
)[[C D
;[[D E
return]] 
Ok]] 
(]] 
)]] 
;]] 
}^^ 
catch__ 
(__ 
	Exception__ 
ex__ 
)__  
{`` 
_loggeraa 
.aa 
LogErroraa  
(aa  !
exaa! #
,aa# $
$straa% B
)aaB C
;aaC D
returnbb 

StatusCodebb !
(bb! "
StatusCodesbb" -
.bb- .(
Status500InternalServerErrorbb. J
,bbJ K
exbbL N
.bbN O
MessagebbO V
)bbV W
;bbW X
}cc 
}dd 	
[ff 	

HttpDeleteff	 
(ff 
$strff %
)ff% &
]ff& '
publicgg 
asyncgg 
Taskgg 
<gg 
IActionResultgg '
>gg' (
DeletaCategoriagg) 8
(gg8 9
[gg9 :
FromBodygg: B
]ggB C
GuidggD H
guidIDggI O
)ggO P
{hh 	
tryii 
{jj 
ifkk 
(kk 
guidIDkk 
==kk 
Guidkk "
.kk" #
Emptykk# (
)kk( )
{ll 
returnmm 

StatusCodemm %
(mm% &
StatusCodesmm& 1
.mm1 2
Status400BadRequestmm2 E
)mmE F
;mmF G
}nn 
CategoriaServicepp  
categoriaServicepp! 1
=pp2 3
newpp4 7
CategoriaServicepp8 H
(ppH I
)ppI J
;ppJ K
awaitrr 
categoriaServicerr &
.rr& '
DeletarCategoriarr' 7
(rr7 8
guidIDrr8 >
)rr> ?
;rr? @
returntt 
Oktt 
(tt 
)tt 
;tt 
}uu 
catchvv 
(vv 
	Exceptionvv 
exvv 
)vv  
{ww 
_loggerxx 
.xx 
LogErrorxx  
(xx  !
exxx! #
,xx# $
$strxx% B
)xxB C
;xxC D
returnyy 

StatusCodeyy !
(yy! "
StatusCodesyy" -
.yy- .(
Status500InternalServerErroryy. J
,yyJ K
exyyL N
.yyN O
MessageyyO V
)yyV W
;yyW X
}zz 
}{{ 	
}|| 
}}} 