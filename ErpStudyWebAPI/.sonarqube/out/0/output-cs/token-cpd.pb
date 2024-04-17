≈
FC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Utilities\Util.cs
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
}		 ¥E
?C:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Startup.cs
	namespace 	
ErpStudyWebAPI
 
{ 
public 

class 
Startup 
{ 
public   
Startup   
(   
IConfiguration   %
configuration  & 3
)  3 4
{!! 	
Configuration"" 
="" 
configuration"" )
;"") *
}## 	
private%% 
IConfiguration%% 
Configuration%% ,
{%%- .
get%%/ 2
;%%2 3
}%%4 5
public(( 
void(( 
ConfigureServices(( %
(((% &
IServiceCollection((& 8
services((9 A
)((A B
{)) 	
services** 
.** 
AddControllers** #
(**# $
)**$ %
;**% &
string,, 
dbHost,, 
=,, 
Environment,, '
.,,' ("
GetEnvironmentVariable,,( >
(,,> ?
$str,,? H
),,H I
;,,I J
string-- 
dbName-- 
=-- 
Environment-- '
.--' ("
GetEnvironmentVariable--( >
(--> ?
$str--? H
)--H I
;--I J
string.. 
dbUser.. 
=.. 
Environment.. '
...' ("
GetEnvironmentVariable..( >
(..> ?
$str..? H
)..H I
;..I J
string// 

dbPassword// 
=// 
Environment//  +
.//+ ,"
GetEnvironmentVariable//, B
(//B C
$str//C S
)//S T
;//T U
Util00 
.00 
StringConexao00 
=00  
$"11 
$str11 
{11 
dbHost11  
}11  !
$str11! +
{11+ ,
dbName11, 2
}112 3
$str113 <
{11< =
dbUser11= C
}11C D
$str11D N
{11N O

dbPassword11O Y
}11Y Z
$str	11Z ë
"
11ë í
;
11í ì
services33 
.33 
AddSwaggerGen33 "
(33" #
c33# $
=>33% '
{44 
c55 
.55 

SwaggerDoc55 
(55 
$str55 !
,55! "
new66 
	Microsoft66 !
.66! "
OpenApi66" )
.66) *
Models66* 0
.660 1
OpenApiInfo661 <
{66= >
Title66? D
=66E F
$str66G W
,66W X
Version66Y `
=66a b
$str66c g
}66h i
)66i j
;66j k
c77 
.77 !
AddSecurityDefinition77 '
(77' (
$str77( 0
,770 1
new88 !
OpenApiSecurityScheme88 -
{99 
In:: 
=:: 
ParameterLocation:: .
.::. /
Header::/ 5
,::5 6
Description;; #
=;;$ %
$str;;& B
,;;B C
Name<< 
=<< 
$str<< .
,<<. /
Type== 
=== 
SecuritySchemeType== 1
.==1 2
Http==2 6
,==6 7
BearerFormat>> $
=>>% &
$str>>' ,
,>>, -
Scheme?? 
=??  
$str??! )
}@@ 
)@@ 
;@@ 
cAA 
.AA "
AddSecurityRequirementAA (
(AA( )
newAA) ,&
OpenApiSecurityRequirementAA- G
{BB 
{CC 
newDD !
OpenApiSecuritySchemeDD 1
{EE 
	ReferenceFF %
=FF& '
newFF( +
OpenApiReferenceFF, <
{FF= >
TypeFF? C
=FFD E
ReferenceTypeFFF S
.FFS T
SecuritySchemeFFT b
,FFb c
IdFFd f
=FFg h
$strFFi q
}FFr s
}GG 
,GG 
newHH 
stringHH "
[HH" #
]HH# $
{HH% &
}HH' (
}II 
}JJ 
)JJ 
;JJ 
stringLL 
	directoryLL  
=LL! "
	AppDomainLL# ,
.LL, -
CurrentDomainLL- :
.LL: ;
BaseDirectoryLL; H
;LLH I
stringMM 
filePathMM 
=MM  !
PathMM" &
.MM& '
CombineMM' .
(MM. /
	directoryMM/ 8
,MM8 9
$strMM: N
)MMN O
;MMO P
cNN 
.NN 
IncludeXmlCommentsNN $
(NN$ %
filePathNN% -
)NN- .
;NN. /
}OO 
)OO 
;OO 
servicesQQ 
.QQ 
AddAuthenticationQQ &
(QQ& '
JwtBearerDefaultsQQ' 8
.QQ8 9 
AuthenticationSchemeQQ9 M
)QQM N
.QQN O
AddJwtBearerQQO [
(QQ[ \
optionsQQ\ c
=>QQd f
{RR 
optionsSS 
.SS %
TokenValidationParametersSS 1
=SS2 3
newSS4 7%
TokenValidationParametersSS8 Q
{TT $
ValidateIssuerSigningKeyUU ,
=UU- .
trueUU/ 3
,UU3 4
IssuerSigningKeyVV $
=VV% &
newVV' * 
SymmetricSecurityKeyVV+ ?
(VV? @
EncodingVV@ H
.VVH I
ASCIIVVI N
.WW 
GetBytesWW !
(WW! "
ConfigurationWW" /
.WW/ 0

GetSectionWW0 :
(WW: ;
$strWW; N
)WWN O
.WWO P
ValueWWP U
)WWU V
)WWV W
,WWW X
ValidateIssuerXX "
=XX# $
falseXX% *
,XX* +
ValidateAudienceYY $
=YY% &
falseYY' ,
}ZZ 
;ZZ 
}[[ 
)[[ 
;[[ 
services^^ 
.^^ 
	AddScoped^^ 
<^^  
ICategoriaRepository^^ 3
,^^3 4
CategoriaRepository^^5 H
>^^H I
(^^I J
)^^J K
;^^K L
services__ 
.__ 
	AddScoped__ 
<__ 
IProdutoRepository__ 1
,__1 2
ProdutoRepository__3 D
>__D E
(__E F
)__F G
;__G H
services`` 
.`` 
	AddScoped`` 
<`` 
IUsuarioRepository`` 1
,``1 2
UsuarioRepository``3 D
>``D E
(``E F
)``F G
;``G H
servicescc 
.cc 
	AddScopedcc 
<cc 
ICategoriaServicecc 0
,cc0 1
CategoriaServicecc2 B
>ccB C
(ccC D
)ccD E
;ccE F
servicesdd 
.dd 
	AddScopeddd 
<dd 
IProdutoServicedd .
,dd. /
ProdutoServicedd0 >
>dd> ?
(dd? @
)dd@ A
;ddA B
servicesee 
.ee 
	AddScopedee 
<ee 
IAuthServiceee +
,ee+ ,
AuthServiceee- 8
>ee8 9
(ee9 :
)ee: ;
;ee; <
}ff 	
publicii 
voidii 
	Configureii 
(ii 
IApplicationBuilderii 1
appii2 5
,ii5 6
IWebHostEnvironmentii7 J
enviiK N
)iiN O
{jj 	
ifkk 
(kk 
envkk 
.kk 
IsDevelopmentkk !
(kk! "
)kk" #
)kk# $
{ll 
appmm 
.mm %
UseDeveloperExceptionPagemm -
(mm- .
)mm. /
;mm/ 0
}nn 
apppp 
.pp 
UseHttpsRedirectionpp #
(pp# $
)pp$ %
;pp% &
apprr 
.rr 

UseRoutingrr 
(rr 
)rr 
;rr 
apptt 
.tt 
UseAuthenticationtt !
(tt! "
)tt" #
;tt# $
appuu 
.uu 
UseAuthorizationuu  
(uu  !
)uu! "
;uu" #
appww 
.ww 
UseEndpointsww 
(ww 
	endpointsww &
=>ww' )
{xx 
	endpointsyy 
.yy 
MapControllersyy (
(yy( )
)yy) *
;yy* +
}zz 
)zz 
;zz 
app|| 
.|| 

UseSwagger|| 
(|| 
)|| 
;|| 
app}} 
.}} 
UseSwaggerUI}} 
(}} 
c}} 
=>}} !
{~~ 
c 
. 
RoutePrefix 
= 
string  &
.& '
Empty' ,
;, -
c
ÄÄ 
.
ÄÄ 
SwaggerEndpoint
ÄÄ !
(
ÄÄ! "
$str
ÄÄ" <
,
ÄÄ< =
$str
ÄÄ> Q
)
ÄÄQ R
;
ÄÄR S
}
ÅÅ 
)
ÅÅ 
;
ÅÅ 
}
ÇÇ 	
}
ÉÉ 
}ÑÑ Ë
_C:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Services\ProdutoServices\ProdutoService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
.! "
ProdutoServices" 1
{ 
public 

class 
ProdutoService 
:  !
IProdutoService" 1
{ 
private		 
readonly		 
IProdutoRepository		 +
_produtoRepository		, >
;		> ?
public 
ProdutoService 
( 
IProdutoRepository 0
produtoRepository1 B
)B C
{ 	
_produtoRepository 
=  
produtoRepository! 2
;2 3
} 	
public 
async 
Task 
AdicionarProduto *
(* +
Produto+ 2
produto3 :
): ;
{ 	
await 
_produtoRepository $
.$ %
InsereProduto% 2
(2 3
produto3 :
): ;
;; <
} 	
} 
} Ì
`C:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Services\ProdutoServices\IProdutoService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
.! "
ProdutoServices" 1
{2 3
public 

	interface 
IProdutoService $
{% &
Task 
AdicionarProduto 
( 
Produto %
produto& -
)- .
;. /
} 
} Ë	
dC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Services\CategoriaServices\ICategoriaService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
.! "
CategoriaServices" 3
{ 
public 

	interface 
ICategoriaService &
{		 
public

 
Task

 
AdicionarCategoria

 &
(

& '
	Categoria

' 0
	categoria

1 :
)

: ;
;

; <
public 
Task 
< 
	Categoria 
> 
RetornaCategoria /
(/ 0
Guid0 4
guidId5 ;
); <
;< =
public 
Task 
< 
List 
< 
	Categoria "
>" #
># $
RetornaCategorias% 6
(6 7
)7 8
;8 9
public 
Task 
AtualizarCategoria &
(& '
	Categoria' 0
	categoria1 :
): ;
;; <
public 
Task 
DeletarCategoria $
($ %
Guid% )
guidId* 0
)0 1
;1 2
} 
} ì
cC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Services\CategoriaServices\CategoriaService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
.! "
CategoriaServices" 3
{ 
public		 

class		 
CategoriaService		 !
:		" #
ICategoriaService		$ 5
{

 
private 
readonly  
ICategoriaRepository - 
_categoriaRepository. B
;B C
public 
CategoriaService 
(   
ICategoriaRepository  4
categoriaRepository5 H
)H I
{ 	 
_categoriaRepository  
=! "
categoriaRepository# 6
;6 7
} 	
public 
async 
Task 
AdicionarCategoria ,
(, -
	Categoria- 6
	categoria7 @
)@ A
{ 	
await  
_categoriaRepository &
.& '
InsereCategoria' 6
(6 7
	categoria7 @
)@ A
;A B
} 	
public 
async 
Task 
< 
	Categoria #
># $
RetornaCategoria% 5
(5 6
Guid6 :
guidId; A
)A B
{ 	
return 
await  
_categoriaRepository -
.- .
RetornaCategoria. >
(> ?
guidId? E
)E F
;F G
} 	
public 
async 
Task 
< 
List 
< 
	Categoria (
>( )
>) *
RetornaCategorias+ <
(< =
)= >
{ 	
return!! 
await!!  
_categoriaRepository!! -
.!!- .
RetornaCategorias!!. ?
(!!? @
)!!@ A
;!!A B
}"" 	
public$$ 
async$$ 
Task$$ 
AtualizarCategoria$$ ,
($$, -
	Categoria$$- 6
	categoria$$7 @
)$$@ A
{%% 	
await''  
_categoriaRepository'' &
.''& '
AtualizaCategoria''' 8
(''8 9
	categoria''9 B
)''B C
;''C D
}(( 	
public** 
async** 
Task** 
DeletarCategoria** *
(*** +
Guid**+ /
guidId**0 6
)**6 7
{++ 	
await--  
_categoriaRepository-- &
.--& '
DeletaCategoria--' 6
(--6 7
guidId--7 =
)--= >
;--> ?
}.. 	
}// 
}00 È
ZC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Services\AuthServices\IAuthService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
.! "
AuthServices" .
{ 
public 

	interface 
IAuthService !
{ 
Task		 
<		 
Guid		 
>		 
RegistraUsuario		 "
(		" #
Usuario		# *
usuario		+ 2
,		2 3
string		4 :
senha		; @
)		@ A
;		A B
Task

 
<

 
string

 
>

 
RealizaLogin

 !
(

! "
string

" (
nomeUsuario

) 4
,

4 5
string

6 <
senha

= B
)

B C
;

C D
Task 
< 
bool 
> 
UsuarioExiste  
(  !
string! '
nomeUsuario( 3
)3 4
;4 5
} 
} ŒJ
YC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Services\AuthServices\AuthService.cs
	namespace 	
ErpStudyWebAPI
 
. 
Services !
.! "
AuthServices" .
{ 
public 

class 
AuthService 
: 
IAuthService +
{ 
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
private 
readonly 
IUsuarioRepository +
_usuarioRepository, >
;> ?
public 
AuthService 
( 
IUsuarioRepository -
usuarioRepository. ?
,? @
IConfigurationA O
configurationP ]
)] ^
{ 	
_configuration 
= 
configuration *
;* +
_usuarioRepository 
=  
usuarioRepository! 2
;2 3
} 	
private 
string 
	CriaToken  
(  !
Usuario! (
usuario) 0
)0 1
{ 	
List 
< 
Claim 
> 
claims 
=  
new! $
List% )
<) *
Claim* /
>/ 0
{1 2
new3 6
Claim7 <
(< =

ClaimTypes= G
.G H
NameIdentifierH V
,V W
usuarioX _
._ `
	UsuarioId` i
.i j
ToStringj r
(r s
)s t
)t u
,u v
neww z
Claim	{ Ä
(
Ä Å

ClaimTypes
Å ã
.
ã å
Name
å ê
,
ê ë
usuario
í ô
.
ô ö
NomeUsuario
ö •
)
• ¶
}
ß ®
;
® © 
SymmetricSecurityKey  
key! $
=% &
new' * 
SymmetricSecurityKey+ ?
(? @
Encoding@ H
.H I
UTF8I M
. 
GetBytes 
( 
_configuration (
.( )

GetSection) 3
(3 4
$str4 G
)G H
.H I
ValueI N
)N O
)O P
;P Q
SigningCredentials!! 
creds!! $
=!!% &
new!!' *
SigningCredentials!!+ =
(!!= >
key!!> A
,!!A B
SecurityAlgorithms!!C U
.!!U V
HmacSha512Signature!!V i
)!!i j
;!!j k#
SecurityTokenDescriptor## #
tokenDescriptor##$ 3
=##4 5
new##6 9#
SecurityTokenDescriptor##: Q
{$$ 
Subject%% 
=%% 
new%% 
ClaimsIdentity%% ,
(%%, -
claims%%- 3
)%%3 4
,%%4 5
Expires&& 
=&& 
DateTime&& "
.&&" #
Now&&# &
.&&& '
AddDays&&' .
(&&. /
$num&&/ 0
)&&0 1
,&&1 2
SigningCredentials'' "
=''# $
creds''% *
}(( 
;(( #
JwtSecurityTokenHandler** #
tokenHandler**$ 0
=**1 2
new**3 6#
JwtSecurityTokenHandler**7 N
(**N O
)**O P
;**P Q
SecurityToken++ 
token++ 
=++  !
tokenHandler++" .
.++. /
CreateToken++/ :
(++: ;
tokenDescriptor++; J
)++J K
;++K L
return-- 
tokenHandler-- 
.--  

WriteToken--  *
(--* +
token--+ 0
)--0 1
;--1 2
}.. 	
public00 
async00 
Task00 
<00 
string00  
>00  !
RealizaLogin00" .
(00. /
string00/ 5
nomeUsuario006 A
,00A B
string00C I
senha00J O
)00O P
{11 	
string22 
tokenUsuarioLogado22 %
;22% &
Usuario44 
usuario44 
=44 
await44 #
_usuarioRepository44$ 6
.446 7
RetornaUsuario447 E
(44E F
nomeUsuario44F Q
.44Q R
ToLower44R Y
(44Y Z
)44Z [
)44[ \
;44\ ]
if66 
(66 
usuario66 
==66 
null66 
)66  
{77 
return99 
null99 
;99 
}:: 
else;; 
if;; 
(;; 
!;; 
VerificaSenhaHash;; '
(;;' (
senha;;( -
,;;- .
usuario;;/ 6
.;;6 7
PasswordHash;;7 C
,;;C D
usuario;;E L
.;;L M
PasswordSalt;;M Y
);;Y Z
);;Z [
{<< 
return>> 
null>> 
;>> 
}?? 
else@@ 
{AA 
tokenUsuarioLogadoBB "
=BB# $
	CriaTokenBB% .
(BB. /
usuarioBB/ 6
)BB6 7
;BB7 8
}CC 
returnEE 
tokenUsuarioLogadoEE %
;EE% &
}FF 	
publicHH 
asyncHH 
TaskHH 
<HH 
GuidHH 
>HH 
RegistraUsuarioHH  /
(HH/ 0
UsuarioHH0 7
usuarioHH8 ?
,HH? @
stringHHA G
senhaHHH M
)HHM N
{II 	
ifJJ 
(JJ 
awaitJJ 
UsuarioExisteJJ #
(JJ# $
usuarioJJ$ +
.JJ+ ,
NomeUsuarioJJ, 7
)JJ7 8
)JJ8 9
{JJ: ;
returnKK 
GuidKK 
.KK 
EmptyKK !
;KK! "
}LL 
CriaHashSenhaNN 
(NN 
senhaNN 
,NN  
outNN! $
byteNN% )
[NN) *
]NN* +
passwordHashNN, 8
,NN8 9
outNN: =
byteNN> B
[NNB C
]NNC D
passwordSaltNNE Q
)NNQ R
;NNR S
usuarioPP 
.PP 
PasswordHashPP  
=PP! "
passwordHashPP# /
;PP/ 0
usuarioQQ 
.QQ 
PasswordSaltQQ  
=QQ! "
passwordSaltQQ# /
;QQ/ 0
returnSS 
awaitSS 
_usuarioRepositorySS +
.SS+ ,
InsereUsuarioSS, 9
(SS9 :
usuarioSS: A
)SSA B
;SSB C
}TT 	
privateVV 
voidVV 
CriaHashSenhaVV "
(VV" #
stringVV# )
senhaVV* /
,VV/ 0
outVV1 4
byteVV5 9
[VV9 :
]VV: ;
	hashSenhaVV< E
,VVE F
outVVG J
byteVVK O
[VVO P
]VVP Q
	senhaSaltVVR [
)VV[ \
{WW 	
usingXX 

HMACSHA512XX 
hmacXX !
=XX" #
newXX$ '
SystemXX( .
.XX. /
SecurityXX/ 7
.XX7 8
CryptographyXX8 D
.XXD E

HMACSHA512XXE O
(XXO P
)XXP Q
;XXQ R
	senhaSaltYY 
=YY 
hmacYY 
.YY 
KeyYY  
;YY  !
	hashSenhaZZ 
=ZZ 
hmacZZ 
.ZZ 
ComputeHashZZ (
(ZZ( )
SystemZZ) /
.ZZ/ 0
TextZZ0 4
.ZZ4 5
EncodingZZ5 =
.ZZ= >
UTF8ZZ> B
.ZZB C
GetBytesZZC K
(ZZK L
senhaZZL Q
)ZZQ R
)ZZR S
;ZZS T
}[[ 	
public]] 
async]] 
Task]] 
<]] 
bool]] 
>]] 
UsuarioExiste]]  -
(]]- .
string]]. 4
nomeUsuario]]5 @
)]]@ A
{^^ 	
return__ 
await__ 
_usuarioRepository__ +
.__+ ,
RetornaUsuario__, :
(__: ;
nomeUsuario__; F
)__F G
!=__H J
null__K O
;__O P
}`` 	
privatebb 
boolbb 
VerificaSenhaHashbb &
(bb& '
stringbb' -
senhabb. 3
,bb3 4
IReadOnlyListbb5 B
<bbB C
bytebbC G
>bbG H
	senhaHashbbI R
,bbR S
bytebbT X
[bbX Y
]bbY Z
	senhaSaltbb[ d
)bbd e
{cc 	
usingdd 

HMACSHA512dd 
hmacdd !
=dd" #
newdd$ '
Systemdd( .
.dd. /
Securitydd/ 7
.dd7 8
Cryptographydd8 D
.ddD E

HMACSHA512ddE O
(ddO P
	senhaSaltddP Y
)ddY Z
;ddZ [
byteee 
[ee 
]ee 
computedHashee 
=ee  !
hmacee" &
.ee& '
ComputeHashee' 2
(ee2 3
Systemee3 9
.ee9 :
Textee: >
.ee> ?
Encodingee? G
.eeG H
UTF8eeH L
.eeL M
GetByteseeM U
(eeU V
senhaeeV [
)ee[ \
)ee\ ]
;ee] ^
returnff 
!ff 
computedHashff  
.ff  !
Whereff! &
(ff& '
(ff' (
tff( )
,ff) *
iff+ ,
)ff, -
=>ff. 0
tff1 2
!=ff3 5
	senhaHashff6 ?
[ff? @
iff@ A
]ffA B
)ffB C
.ffC D
AnyffD G
(ffG H
)ffH I
;ffI J
}gg 	
}hh 
}ii ù
`C:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Repository\UsuarioRepo\UsuarioRepository.cs
	namespace 	
ErpStudyWebAPI
 
. 

Repository #
.# $
UsuarioRepo$ /
{		 
public

 

class

 
UsuarioRepository

 "
:

# $
IUsuarioRepository

% 7
{ 
private 
readonly 
string 
_connectionString  1
=2 3
Util4 8
.8 9
StringConexao9 F
;F G
public 
async 
Task 
< 
Guid 
> 
InsereUsuario  -
(- .
Usuario. 5
usuario6 =
)= >
{ 	
StringBuilder 
stringBuilder '
=( )
new* -
StringBuilder. ;
(; <
)< =
;= >
await 
using 
SqlConnection %

connection& 0
=1 2
new3 6
SqlConnection7 D
(D E
_connectionStringE V
)V W
;W X
await 

connection 
. 
	OpenAsync &
(& '
)' (
;( )
stringBuilder 
. 
Append  
(  !
$str! A
)A B
;B C
return 
Guid 
. 
Empty 
; 
} 	
public 
async 
Task 
< 
Usuario !
>! "
RetornaUsuario# 1
(1 2
string2 8
nomeUsuario9 D
)D E
{ 	
if 
( 
String 
. 
IsNullOrWhiteSpace )
() *
nomeUsuario* 5
)5 6
)6 7
{ 
return 
null 
; 
}   
await"" 
using"" 
SqlConnection"" %

connection""& 0
=""1 2
new""3 6
SqlConnection""7 D
(""D E
_connectionString""E V
)""V W
;""W X
await## 

connection## 
.## 
	OpenAsync## &
(##& '
)##' (
;##( )
const%% 
string%% 
sQuery%% 
=%%  !
$str%%" \
;%%\ ]
await&& 
using&& 

SqlCommand&& "
command&&# *
=&&+ ,
new&&- 0

SqlCommand&&1 ;
(&&; <
sQuery&&< B
,&&B C

connection&&D N
)&&N O
;&&O P
command(( 
.(( 

Parameters(( 
.(( 
AddWithValue(( +
(((+ ,
$str((, :
,((: ;
nomeUsuario((< G
)((G H
;((H I
Usuario)) 
usuario)) 
=)) 
()) 
Usuario)) &
)))& '
await))' ,
command))- 4
.))4 5
ExecuteScalarAsync))5 G
())G H
)))H I
;))I J
return++ 
usuario++ 
;++ 
},, 	
}-- 
}.. ˝
aC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Repository\UsuarioRepo\IUsuarioRepository.cs
	namespace 	
ErpStudyWebAPI
 
. 

Repository #
.# $
UsuarioRepo$ /
{ 
public 

	interface 
IUsuarioRepository '
{ 
public		 
Task		 
<		 
Guid		 
>		 
InsereUsuario		 '
(		' (
Usuario		( /
usuario		0 7
)		7 8
;		8 9
public

 
Task

 
<

 
Usuario

 
>

 
RetornaUsuario

 +
(

+ ,
string

, 2
nomeUsuario

3 >
)

> ?
;

? @
} 
} ≈H
`C:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Repository\ProdutoRepo\ProdutoRepository.cs
	namespace 	
ErpStudyWebAPI
 
. 

Repository #
{ 
public 

class 
ProdutoRepository "
:# $
IProdutoRepository% 7
{ 
private 
readonly 
string 
_connectionString  1
=2 3
Util4 8
.8 9
StringConexao9 F
;F G
public 
async 
Task 
InsereProduto '
(' (
Produto( /
produto0 7
)7 8
{ 	
StringBuilder 
stringBuilder '
=( )
new* -
StringBuilder. ;
(; <
)< =
;= >
await 
using 
SqlConnection %

connection& 0
=1 2
new3 6
SqlConnection7 D
(D E
_connectionStringE V
)V W
;W X
await 

connection 
. 
	OpenAsync &
(& '
)' (
;( )
stringBuilder 
. 
Append  
(  !
$str! 8
)8 9
;9 :
stringBuilder 
. 
Append  
(  !
$str! &
)& '
;' (
stringBuilder 
. 
Append  
(  !
$str! f
)f g
;g h
stringBuilder 
. 
Append  
(  !
$str! &
)& '
;' (
await 
using 

SqlCommand "
command# *
=+ ,
new- 0

SqlCommand1 ;
(; <
stringBuilder< I
.I J
ToStringJ R
(R S
)S T
,T U

connectionV `
)` a
;a b
command   
.   

Parameters   
.   
AddWithValue   +
(  + ,
$str  , 3
,  3 4
produto  5 <
.  < =
Nome  = A
)  A B
;  B C
command!! 
.!! 

Parameters!! 
.!! 
AddWithValue!! +
(!!+ ,
$str!!, 8
,!!8 9
produto!!: A
.!!A B
	CodigoSKU!!B K
)!!K L
;!!L M
command"" 
."" 

Parameters"" 
."" 
AddWithValue"" +
(""+ ,
$str"", 9
,""9 :
produto""; B
.""B C

PrecoVenda""C M
)""M N
;""N O
command## 
.## 

Parameters## 
.## 
AddWithValue## +
(##+ ,
$str##, 6
,##6 7
produto##8 ?
.##? @
Unidade##@ G
)##G H
;##H I
command$$ 
.$$ 

Parameters$$ 
.$$ 
AddWithValue$$ +
($$+ ,
$str$$, 7
,$$7 8
produto$$9 @
.$$@ A
Condicao$$A I
)$$I J
;$$J K
command%% 
.%% 

Parameters%% 
.%% 
AddWithValue%% +
(%%+ ,
$str%%, :
,%%: ;
produto%%< C
.%%C D
	Categoria%%D M
.%%M N
CategoriaID%%N Y
)%%Y Z
;%%Z [
await'' 
command'' 
.''  
ExecuteNonQueryAsync'' .
(''. /
)''/ 0
;''0 1
}(( 	
public** 
async** 
Task** 
<** 
List** 
<** 
Produto** &
>**& '
>**' ( 
RetornaTodosProdutos**) =
(**= >
)**> ?
{++ 	
await,, 
using,, 
SqlConnection,, %

connection,,& 0
=,,1 2
new,,3 6
SqlConnection,,7 D
(,,D E
_connectionString,,E V
),,V W
;,,W X
await-- 

connection-- 
.-- 
	OpenAsync-- &
(--& '
)--' (
;--( )
const// 
string// 
sQuery// 
=//  !
$str00 l
;00l m
await22 
using22 

SqlCommand22 "
command22# *
=22+ ,
new22- 0

SqlCommand221 ;
(22; <
sQuery22< B
,22B C

connection22D N
)22N O
;22O P
await44 
using44 
SqlDataReader44 %
reader44& ,
=44- .
await44/ 4
command445 <
.44< =
ExecuteReaderAsync44= O
(44O P
)44P Q
;44Q R
List66 
<66 
Produto66 
>66 
produtos66 "
=66# $
new66% (
List66) -
<66- .
Produto66. 5
>665 6
(666 7
)667 8
;668 9
while88 
(88 
reader88 
.88 
Read88 
(88 
)88  
)88  !
{99 
Produto:: 
produto:: 
=::  !
new::" %
Produto::& -
{;; 
	ProdutoID<< 
=<< 
reader<<  &
.<<& '
GetGuid<<' .
(<<. /
reader<</ 5
.<<5 6

GetOrdinal<<6 @
(<<@ A
$str<<A L
)<<L M
)<<M N
,<<N O
Nome== 
=== 
reader== !
.==! "
	GetString==" +
(==+ ,
reader==, 2
.==2 3

GetOrdinal==3 =
(=== >
$str==> D
)==D E
)==E F
,==F G
	CodigoSKU>> 
=>> 
reader>>  &
.>>& '
	GetString>>' 0
(>>0 1
reader>>1 7
.>>7 8

GetOrdinal>>8 B
(>>B C
$str>>C N
)>>N O
)>>O P
,>>P Q

PrecoVenda?? 
=??  
reader??! '
.??' (
	GetDouble??( 1
(??1 2
reader??2 8
.??8 9

GetOrdinal??9 C
(??C D
$str??D P
)??P Q
)??Q R
,??R S
Unidade@@ 
=@@ 
(@@ 
Unidade@@ &
)@@& '
reader@@' -
.@@- .
GetInt32@@. 6
(@@6 7
reader@@7 =
.@@= >

GetOrdinal@@> H
(@@H I
$str@@I R
)@@R S
)@@S T
,@@T U
CondicaoAA 
=AA 
(AA  
CondicaoAA  (
)AA( )
readerAA) /
.AA/ 0
GetInt32AA0 8
(AA8 9
readerAA9 ?
.AA? @

GetOrdinalAA@ J
(AAJ K
$strAAK U
)AAU V
)AAV W
,AAW X
	CategoriaBB 
=BB 
newBB  #
	CategoriaBB$ -
{CC 
CategoriaIDDD #
=DD$ %
readerDD& ,
.DD, -
GetGuidDD- 4
(DD4 5
readerDD5 ;
.DD; <

GetOrdinalDD< F
(DDF G
$strDDG T
)DDT U
)DDU V
,DDV W
NomeEE 
=EE 
readerEE %
.EE% &
	GetStringEE& /
(EE/ 0
readerEE0 6
.EE6 7

GetOrdinalEE7 A
(EEA B
$strEEB H
)EEH I
)EEI J
}FF 
}GG 
;GG 
produtosII 
.II 
AddII 
(II 
produtoII $
)II$ %
;II% &
}JJ 
awaitLL 
readerLL 
.LL 

CloseAsyncLL #
(LL# $
)LL$ %
;LL% &
returnNN 
produtosNN 
;NN 
}OO 	
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
ProdutoQQ !
>QQ! "
RetornaProdutoQQ# 1
(QQ1 2
GuidQQ2 6
produtoGuidQQ7 B
)QQB C
{RR 	
awaitSS 
usingSS 
SqlConnectionSS %

connectionSS& 0
=SS1 2
newSS3 6
SqlConnectionSS7 D
(SSD E
_connectionStringSSE V
)SSV W
;SSW X
ProdutoTT 
produtoTT 
;TT 
awaitUU 

connectionUU 
.UU 
	OpenAsyncUU &
(UU& '
)UU' (
;UU( )
constWW 
stringWW 
sQueryWW 
=WW  !
$strWW" `
;WW` a
awaitYY 
usingYY 

SqlCommandYY "
commandYY# *
=YY+ ,
newYY- 0

SqlCommandYY1 ;
(YY; <
sQueryYY< B
,YYB C

connectionYYD N
)YYN O
;YYO P
command[[ 
.[[ 

Parameters[[ 
.[[ 
AddWithValue[[ +
([[+ ,
$str[[, 8
,[[8 9
produtoGuid[[: E
)[[E F
;[[F G
produto]] 
=]] 
(]] 
Produto]] 
)]] 
command]] &
.]]& '
ExecuteScalar]]' 4
(]]4 5
)]]5 6
;]]6 7
return__ 
produto__ 
;__ 
}`` 	
}aa 
}bb Á
aC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Repository\ProdutoRepo\IProdutoRepository.cs
	namespace 	
ErpStudyWebAPI
 
. 

Repository #
.# $
ProdutoRepo$ /
{ 
public 

	interface 
IProdutoRepository '
{		 
Task

 
InsereProduto

 
(

 
Produto

 "
produto

# *
)

* +
;

+ ,
Task 
< 
List 
< 
Produto 
> 
>  
RetornaTodosProdutos 0
(0 1
)1 2
;2 3
Task 
< 
Produto 
> 
RetornaProduto $
($ %
Guid% )
produtoGuid* 5
)5 6
;6 7
} 
} Å	
eC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Repository\CategoriaRepo\ICategoriaRepository.cs
	namespace 	
ErpStudyWebAPI
 
. 

Repository #
.# $
CategoriaRepo$ 1
{ 
public 

	interface  
ICategoriaRepository )
{		 
Task

 
InsereCategoria

 
(

 
	Categoria

 &
	categoria

' 0
)

0 1
;

1 2
Task 
AtualizaCategoria 
( 
	Categoria (
	categoria) 2
)2 3
;3 4
Task 
< 
	Categoria 
> 
RetornaCategoria (
(( )
Guid) -
guidId. 4
)4 5
;5 6
Task 
< 
List 
< 
	Categoria 
> 
> 
RetornaCategorias /
(/ 0
)0 1
;1 2
Task 
DeletaCategoria 
( 
Guid !
guidId" (
)( )
;) *
} 
} ÚC
dC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Repository\CategoriaRepo\CategoriaRepository.cs
	namespace		 	
ErpStudyWebAPI		
 
.		 

Repository		 #
.		# $
CategoriaRepo		$ 1
{

 
public 

class 
CategoriaRepository $
:% & 
ICategoriaRepository' ;
{ 
private 
readonly 
string 
_connectionString  1
=2 3
Util4 8
.8 9
StringConexao9 F
;F G
public 
async 
Task 
InsereCategoria )
() *
	Categoria* 3
	categoria4 =
)= >
{ 	
using 
SqlConnection 

connection  *
=+ ,
new- 0
SqlConnection1 >
(> ?
_connectionString? P
)P Q
;Q R

connection 
. 
Open 
( 
) 
; 
string 
sQuery 
= 
$str K
;K L
using 

SqlCommand 
command $
=% &
new' *

SqlCommand+ 5
(5 6
sQuery6 <
,< =

connection> H
)H I
;I J
command 
. 

Parameters 
. 
AddWithValue +
(+ ,
$str, 3
,3 4
	categoria5 >
.> ?
Nome? C
)C D
;D E
await 
command 
.  
ExecuteNonQueryAsync .
(. /
)/ 0
;0 1
} 	
public 
async 
Task 
AtualizaCategoria +
(+ ,
	Categoria, 5
	categoria6 ?
)? @
{ 	
await 
using 
SqlConnection %

connection& 0
=1 2
new3 6
SqlConnection7 D
(D E
_connectionStringE V
)V W
;W X
await 

connection 
. 
	OpenAsync &
(& '
)' (
;( )
const!! 
string!! 
sQuery!! 
=!!  !
$str!!" h
;!!h i
await## 
using## 

SqlCommand## "
command### *
=##+ ,
new##- 0

SqlCommand##1 ;
(##; <
sQuery##< B
,##B C

connection##D N
)##N O
;##O P
command%% 
.%% 

Parameters%% 
.%% 
AddWithValue%% +
(%%+ ,
$str%%, 3
,%%3 4
	categoria%%5 >
.%%> ?
Nome%%? C
)%%C D
;%%D E
command&& 
.&& 

Parameters&& 
.&& 
AddWithValue&& +
(&&+ ,
$str&&, :
,&&: ;
	categoria&&< E
.&&E F
CategoriaID&&F Q
)&&Q R
;&&R S
await(( 
command(( 
.((  
ExecuteNonQueryAsync(( .
(((. /
)((/ 0
;((0 1
})) 	
public++ 
async++ 
Task++ 
<++ 
	Categoria++ #
>++# $
RetornaCategoria++% 5
(++5 6
Guid++6 :
guidId++; A
)++A B
{,, 	
if-- 
(-- 
guidId-- 
==-- 
Guid-- 
.-- 
Empty-- $
)--$ %
{.. 
return// 
null// 
;// 
}00 
await22 
using22 
SqlConnection22 %

connection22& 0
=221 2
new223 6
SqlConnection227 D
(22D E
_connectionString22E V
)22V W
;22W X
await44 

connection44 
.44 
	OpenAsync44 &
(44& '
)44' (
;44( )
const66 
string66 
sQuery66 
=66  !
$str66" ^
;66^ _
await88 
using88 

SqlCommand88 "
command88# *
=88+ ,
new88- 0

SqlCommand881 ;
(88; <
sQuery88< B
,88B C

connection88D N
)88N O
;88O P
command:: 
.:: 

Parameters:: 
.:: 
AddWithValue:: +
(::+ ,
$str::, :
,::: ;
guidId::< B
)::B C
;::C D
	Categoria<< 
	categoria<< 
=<<  !
(<<" #
	Categoria<<# ,
)<<, -
await<<- 2
command<<3 :
.<<: ;
ExecuteScalarAsync<<; M
(<<M N
)<<N O
;<<O P
return>> 
	categoria>> 
;>> 
}?? 	
publicAA 
asyncAA 
TaskAA 
<AA 
ListAA 
<AA 
	CategoriaAA (
>AA( )
>AA) *
RetornaCategoriasAA+ <
(AA< =
)AA= >
{BB 	
awaitCC 
usingCC 
SqlConnectionCC %

connectionCC& 0
=CC1 2
newCC3 6
SqlConnectionCC7 D
(CCD E
_connectionStringCCE V
)CCV W
;CCW X
awaitEE 

connectionEE 
.EE 
	OpenAsyncEE &
(EE& '
)EE' (
;EE( )
constGG 
stringGG 
sQueryGG 
=GG  !
$strGG" =
;GG= >
awaitII 
usingII 

SqlCommandII "
commandII# *
=II+ ,
newII- 0

SqlCommandII1 ;
(II; <
sQueryII< B
,IIB C

connectionIID N
)IIN O
;IIO P
awaitKK 
usingKK 
SqlDataReaderKK %
readerKK& ,
=KK- .
awaitKK/ 4
commandKK5 <
.KK< =
ExecuteReaderAsyncKK= O
(KKO P
)KKP Q
;KKQ R
ListMM 
<MM 
	CategoriaMM 
>MM 
listcategoriasMM *
=MM+ ,
newMM- 0
ListMM1 5
<MM5 6
	CategoriaMM6 ?
>MM? @
(MM@ A
)MMA B
;MMB C
whileOO 
(OO 
awaitOO 
readerOO 
.OO  
	ReadAsyncOO  )
(OO) *
)OO* +
)OO+ ,
{PP 
	CategoriaQQ 
	categoriaQQ #
=QQ$ %
newQQ& )
	CategoriaQQ* 3
{RR 
CategoriaIDSS 
=SS  !
readerSS" (
.SS( )
GetGuidSS) 0
(SS0 1
$strSS1 >
)SS> ?
,SS? @
NomeSSA E
=SSF G
readerSSH N
.SSN O
	GetStringSSO X
(SSX Y
readerSSY _
.SS_ `

GetOrdinalSS` j
(SSj k
$strSSk q
)SSq r
)SSr s
}TT 
;TT 
listcategoriasVV 
.VV 
AddVV "
(VV" #
	categoriaVV# ,
)VV, -
;VV- .
}WW 
returnYY 
listcategoriasYY !
;YY! "
}ZZ 	
public\\ 
async\\ 
Task\\ 
DeletaCategoria\\ )
(\\) *
Guid\\* .
guidId\\/ 5
)\\5 6
{]] 	
if^^ 
(^^ 
guidId^^ 
==^^ 
Guid^^ 
.^^ 
Empty^^ $
)^^$ %
{__ 
return`` 
;`` 
}aa 
awaitcc 
usingcc 
SqlConnectioncc %

connectioncc& 0
=cc1 2
newcc3 6
SqlConnectioncc7 D
(ccD E
_connectionStringccE V
)ccV W
;ccW X
awaitee 

connectionee 
.ee 
	OpenAsyncee &
(ee& '
)ee' (
;ee( )
constgg 
stringgg 
sQuerygg 
=gg  !
$strgg" [
;gg[ \
awaitii 
usingii 

SqlCommandii "
commandii# *
=ii+ ,
newii- 0

SqlCommandii1 ;
(ii; <
sQueryii< B
,iiB C

connectioniiD N
)iiN O
;iiO P
commandkk 
.kk 

Parameterskk 
.kk 
AddWithValuekk +
(kk+ ,
$strkk, :
,kk: ;
guidIdkk< B
)kkB C
;kkC D
awaitmm 
commandmm 
.mm  
ExecuteNonQueryAsyncmm .
(mm. /
)mm/ 0
;mm0 1
}nn 	
}oo 
}pp õ

?C:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Program.cs
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
} ƒ
FC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Models\Usuario.cs
	namespace 	
ErpStudyWebAPI
 
. 
Models 
{  !
public 

class 
Usuario 
{ 
public 
Guid 
	UsuarioId 
{ 
get "
;" #
set$ '
;' (
}( )
public 
string 
NomeUsuario !
{" #
get# &
;& '
set( +
;+ ,
}, -
public 
byte 
[ 
] 
PasswordHash "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
byte 
[ 
] 
PasswordSalt "
{# $
get% (
;( )
set* -
;- .
}/ 0
}		 
}

 ÿ

FC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Models\Produto.cs
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
} ∑
LC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Models\Enums\Unidade.cs
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
 Ì
MC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Models\Enums\Condicao.cs
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
} Ñ
VC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Models\DTOs\UsuarioCadastroDto.cs
	namespace 	
ErpStudyWebAPI
 
. 
Models 
.  
DTOs  $
{ 
public 

class 
UsuarioCadastroDto #
{ 
public 
string 
NomeUsuario !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
Senha 
{ 
get !
;! "
set# &
;& '
}( )
} 
} …
HC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Models\Categoria.cs
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
 †!
UC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Controllers\UsuarioController.cs
	namespace 	
ErpStudyWebAPI
 
. 
Controllers $
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
UsuarioController "
:# $
ControllerBase% 3
{ 
private 
readonly 
ILogger  
<  !
UsuarioController! 2
>2 3
_logger4 ;
;; <
private 
readonly 
IAuthService %
_authService& 2
;2 3
public 
UsuarioController  
(  !
ILogger! (
<( )
UsuarioController) :
>: ;
logger< B
,B C
IAuthServiceD P
authServiceQ \
)\ ]
{ 	
_logger 
= 
logger 
; 
_authService 
= 
authService &
;& '
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
RealizaLogin) 5
(5 6
UsuarioCadastroDto6 H
usuarioCadastroDtoI [
)[ \
{ 	
try 
{ 
await 
_authService "
." #
RealizaLogin# /
(/ 0
usuarioCadastroDto0 B
.B C
NomeUsuarioC N
,N O
usuarioCadastroDtoP b
.b c
Senhac h
)h i
;i j
}   
catch!! 
(!! 
	Exception!! 
err!!  
)!!  !
{"" 
_logger## 
.## 
LogError##  
(##  !
err##! $
,##$ %
$str##& E
)##E F
;##F G
return$$ 

StatusCode$$ !
($$! "
StatusCodes$$" -
.$$- .(
Status500InternalServerError$$. J
,$$J K
err$$L O
.$$O P
Message$$P W
)$$W X
;$$X Y
}%% 
return'' 
Ok'' 
('' 
)'' 
;'' 
}(( 	
[** 	
HttpPost**	 
]** 
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
InsereUsuario++) 6
(++6 7
UsuarioCadastroDto++7 I
usuarioCadastro++J Y
)++Y Z
{,, 	
Guid-- 
guid-- 
;-- 
try// 
{00 
guid11 
=11 
await22 
_authService22 &
.22& '
RegistraUsuario22' 6
(33 
new33 
Usuario33 $
{33% &
NomeUsuario33& 1
=332 3
usuarioCadastro334 C
.33C D
NomeUsuario33D O
}33O P
,33P Q
usuarioCadastro33R a
.33a b
Senha33b g
)33g h
;33h i
if55 
(55 
guid55 
==55 
Guid55  
.55  !
Empty55! &
)55& '
{66 
return77 

StatusCode77 %
(77% &
StatusCodes77& 1
.771 2
Status400BadRequest772 E
)77E F
;77F G
}88 
}99 
catch:: 
(:: 
	Exception:: 
err::  
)::  !
{;; 
_logger<< 
.<< 
LogError<<  
(<<  !
err<<! $
,<<$ %
$str<<& G
)<<G H
;<<H I
return== 

StatusCode== !
(==! "
StatusCodes==" -
.==- .(
Status500InternalServerError==. J
,==J K
err==L O
.==O P
Message==P W
)==W X
;==X Y
}>> 
return@@ 
Ok@@ 
(@@ 
guid@@ 
)@@ 
;@@ 
}AA 	
}BB 
}CC √
UC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Controllers\ProdutoController.cs
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
ProdutoController "
:# $
ControllerBase% 3
{ 
private 
readonly 
ILogger  
<  !
ProdutoController! 2
>2 3
_logger4 ;
;; <
private 
readonly 
IProdutoService (
_produtoService) 8
;8 9
public 
ProdutoController  
(  !
ILogger! (
<( )
ProdutoController) :
>: ;
logger< B
,B C
IProdutoServiceD S
produtoServiceT b
)b c
{ 	
_logger 
= 
logger 
; 
_produtoService 
= 
produtoService ,
;, -
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
RetornaProdutos )
() *
)* +
{ 	
try 
{ 
} 
catch 
( 
	Exception 
err  
)  !
{   
}!! 
}"" 	
[++ 	
HttpPost++	 
]++ 
public,, 
async,, 
Task,, 
<,, 
IActionResult,, '
>,,' (
AdicionarProduto,,) 9
(,,9 :
Produto,,: A
produto,,B I
),,I J
{-- 	
try.. 
{// 
if00 
(00 
produto00 
==00 
null00 #
)00# $
{11 
return22 

BadRequest22 %
(22% &
)22& '
;22' (
}33 
await55 
_produtoService55 %
.55% &
AdicionarProduto55& 6
(556 7
produto557 >
)55> ?
;55? @
return77 

StatusCode77 !
(77! "
StatusCodes77" -
.77- .
Status201Created77. >
)77> ?
;77? @
}88 
catch99 
(99 
	Exception99 
err99  
)99  !
{:: 
return;; 

StatusCode;; !
(;;! "
StatusCodes;;" -
.;;- .(
Status500InternalServerError;;. J
);;J K
;;;K L
}<< 
}== 	
}>> 
}?? ãH
WC:\Users\p-mesantos\Erp-Study-Web-API\ErpStudyWebAPI\Controllers\CategoriaController.cs
	namespace 	
ErpStudyWebAPI
 
. 
Controllers $
{ 
[ 
	Authorize 
] 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
CategoriaController $
:% &
ControllerBase' 5
{ 
public 
ClaimsPrincipal "
ClaimsPrincipalUsuario 5
{6 7
get8 ;
;; <
}= >
private 
readonly 
ILogger  
<  !
CategoriaController! 4
>4 5
_logger6 =
;= >
private 
readonly 
ICategoriaService *
_categoriaService+ <
;< =
public 
CategoriaController "
(" #
ILogger# *
<* +
CategoriaController+ >
>> ?
logger@ F
,F G
ICategoriaServiceH Y
categoriaServiceZ j
)j k
{ 	
_logger 
= 
logger 
; 
_categoriaService 
=  
categoriaService! 1
;1 2
} 	
['' 	
HttpPost''	 
('' 
$str'' &
)''& '
]''' (
[(( 	 
ProducesResponseType((	 
((( 
typeof(( $
((($ %
	Categoria((% .
)((. /
,((/ 0
$num((1 4
)((4 5
]((5 6
[)) 	 
ProducesResponseType))	 
()) 
$num)) !
)))! "
]))" #
[** 	 
ProducesResponseType**	 
(** 
$num** !
)**! "
]**" #
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
AdicionarCategoria++) ;
(++; <
[++< =
FromBody++= E
]++E F
	Categoria++G P
	categoria++Q Z
)++Z [
{,, 	
try-- 
{.. 
if// 
(// 
	categoria// 
==//  
null//! %
)//% &
{00 
return11 

StatusCode11 %
(11% &
StatusCodes11& 1
.111 2
Status400BadRequest112 E
)11E F
;11F G
}22 
await44 
_categoriaService44 '
.44' (
AdicionarCategoria44( :
(44: ;
	categoria44; D
)44D E
;44E F
return66 

StatusCode66 !
(66! "
StatusCodes66" -
.66- .
Status201Created66. >
)66> ?
;66? @
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
$str::% ?
)::? @
;::@ A
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
[FF 	
HttpPostFF	 
(FF 
$strFF $
)FF$ %
]FF% &
publicGG 
asyncGG 
TaskGG 
<GG 
IActionResultGG '
>GG' (
RetornaCategoriaGG) 9
(GG9 :
[GG: ;
FromBodyGG; C
]GGC D
GuidGGE I
guidIDGGJ P
)GGP Q
{HH 	
tryII 
{JJ 
ifMM 
(MM 
guidIDMM 
==MM 
GuidMM "
.MM" #
EmptyMM# (
)MM( )
returnNN 

StatusCodeNN %
(NN% &
StatusCodesNN& 1
.NN1 2
Status400BadRequestNN2 E
)NNE F
;NNF G
returnPP 
OkPP 
(PP 
awaitPP 
_categoriaServicePP  1
.PP1 2
RetornaCategoriaPP2 B
(PPB C
guidIDPPC I
)PPI J
)PPJ K
;PPK L
}QQ 
catchRR 
(RR 
	ExceptionRR 
exRR 
)RR  
{SS 
_loggerTT 
.TT 
LogErrorTT  
(TT  !
exTT! #
,TT# $
$strTT% >
)TT> ?
;TT? @
returnUU 

StatusCodeUU !
(UU! "
StatusCodesUU" -
.UU- .(
Status500InternalServerErrorUU. J
,UUJ K
exUUL N
.UUN O
MessageUUO V
)UUV W
;UUW X
}VV 
}WW 	
[__ 	
HttpGet__	 
(__ 
$str__ $
)__$ %
]__% &
public`` 
async`` 
Task`` 
<`` 
IActionResult`` '
>``' (
RetornaCategorias``) :
(``: ;
)``; <
{aa 	
trybb 
{cc 
returndd 
Okdd 
(dd 
awaitdd 
_categoriaServicedd  1
.dd1 2
RetornaCategoriasdd2 C
(ddC D
)ddD E
)ddE F
;ddF G
}ee 
catchff 
(ff 
	Exceptionff 
exff 
)ff  
{gg 
_loggerhh 
.hh 
LogErrorhh  
(hh  !
exhh! #
,hh# $
$strhh% B
)hhB C
;hhC D
returnii 

StatusCodeii !
(ii! "
StatusCodesii" -
.ii- .(
Status500InternalServerErrorii. J
,iiJ K
exiiL N
.iiN O
MessageiiO V
)iiV W
;iiW X
}jj 
}kk 	
[ss 	
HttpPutss	 
(ss 
$strss $
)ss$ %
]ss% &
publictt 
asynctt 
Tasktt 
<tt 
IActionResulttt '
>tt' (
AtualizaCategoriatt) :
(tt: ;
[tt; <
FromBodytt< D
]ttD E
	CategoriattF O
	categoriattP Y
)ttY Z
{uu 	
tryvv 
{ww 
ifxx 
(xx 
	categoriaxx 
==xx  
nullxx! %
)xx% &
{yy 
returnzz 

StatusCodezz %
(zz% &
StatusCodeszz& 1
.zz1 2
Status400BadRequestzz2 E
)zzE F
;zzF G
}{{ 
await}} 
_categoriaService}} '
.}}' (
AtualizarCategoria}}( :
(}}: ;
	categoria}}; D
)}}D E
;}}E F
return 
Ok 
( 
) 
; 
}
ÄÄ 
catch
ÅÅ 
(
ÅÅ 
	Exception
ÅÅ 
ex
ÅÅ 
)
ÅÅ  
{
ÇÇ 
_logger
ÉÉ 
.
ÉÉ 
LogError
ÉÉ  
(
ÉÉ  !
ex
ÉÉ! #
,
ÉÉ# $
$str
ÉÉ% B
)
ÉÉB C
;
ÉÉC D
return
ÑÑ 

StatusCode
ÑÑ !
(
ÑÑ! "
StatusCodes
ÑÑ" -
.
ÑÑ- .*
Status500InternalServerError
ÑÑ. J
,
ÑÑJ K
ex
ÑÑL N
.
ÑÑN O
Message
ÑÑO V
)
ÑÑV W
;
ÑÑW X
}
ÖÖ 
}
ÜÜ 	
[
éé 	

HttpDelete
éé	 
(
éé 
$str
éé %
)
éé% &
]
éé& '
public
èè 
async
èè 
Task
èè 
<
èè 
IActionResult
èè '
>
èè' (
DeletaCategoria
èè) 8
(
èè8 9
[
èè9 :
FromBody
èè: B
]
èèB C
Guid
èèD H
guidID
èèI O
)
èèO P
{
êê 	
try
ëë 
{
íí 
if
ìì 
(
ìì 
guidID
ìì 
==
ìì 
Guid
ìì "
.
ìì" #
Empty
ìì# (
)
ìì( )
{
îî 
return
ïï 

StatusCode
ïï %
(
ïï% &
StatusCodes
ïï& 1
.
ïï1 2!
Status400BadRequest
ïï2 E
)
ïïE F
;
ïïF G
}
ññ 
await
òò 
_categoriaService
òò '
.
òò' (
DeletarCategoria
òò( 8
(
òò8 9
guidID
òò9 ?
)
òò? @
;
òò@ A
return
öö 
Ok
öö 
(
öö 
)
öö 
;
öö 
}
õõ 
catch
úú 
(
úú 
	Exception
úú 
ex
úú 
)
úú  
{
ùù 
_logger
ûû 
.
ûû 
LogError
ûû  
(
ûû  !
ex
ûû! #
,
ûû# $
$str
ûû% B
)
ûûB C
;
ûûC D
return
üü 

StatusCode
üü !
(
üü! "
StatusCodes
üü" -
.
üü- .*
Status500InternalServerError
üü. J
,
üüJ K
ex
üüL N
.
üüN O
Message
üüO V
)
üüV W
;
üüW X
}
†† 
}
°° 	
}
¢¢ 
}££ 