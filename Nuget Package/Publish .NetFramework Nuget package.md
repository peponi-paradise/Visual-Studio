
# Publish .NetFramework Nuget package

<br>

## 1. 소개글

<br>

1. [NuGet](https://www.nuget.org/)은 클래스 라이브러리를 온라인 또는 로컬 스토리지에서 쉽게 다운받아 사용 가능하게 해준다.
2. 소프트웨어를 제작하면서 NuGet을 다운받는 경우는 흔하게 있지만, 드물게 업로드 하는 경우도 있다.
3. 여기서는 NuGet CLI를 활용해 업로드 하는 방법을 알아본다.
    (.NetFramework의 경우 [.NET CLI를 통한 패키지 생성](https://learn.microsoft.com/ko-kr/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli)을 지원하지 않는다)

<br>

## 2. 준비 사항

<br>

1. [NuGet](https://www.nuget.org/) 계정 : 업로드를 위한 API 키를 제공한다.
    ***Information*** : NuGet에 한번 업로드를 하면, 패키지를 삭제하는 방법이 규정 위반 말고는 없다. 테스트의 경우 아래 경로를 통해 진행하는 것이 좋다.
2. [NuGet test site](https://int.nugettest.org/) 계정 : 패키지 테스트용 웹사이트이다. Nuget.org에서 제공하는 기능을 동일하게 제공한다.
3. [NuGet CLI 다운로드](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe) : 다운로드 후 환경 변수(PATH)에 추가 또는 프로젝트 폴더에 위치시킨다.

<br>

## 3. 클래스 라이브러리 프로젝트 제작

<br>

<table>
<tr>
<th>
순서
</th>
<th>
내용
</th>
<th>
비고
</th>
</tr>

<tr>
<td>
1
</td>
<td>
C# 클래스 라이브러리 (.NET Framework)를 생성한다
</td>
<td>
<img src=".NetFramework Image/1.PNG" width="100%">
</td>
</tr>

<tr>
<td>
2
</td>
<td>
테스트용 코드 작성 후 프로젝트 속성을 작성한다.<br>
프로젝트 속성에서 작성할 요소 : 제목, 설명, 회사, 저작권, 어셈블리 버전
</td>
<td>

```cs
namespace TestLibrary
{
    public class AddInts
    {
        public int Result { get; set; } = int.MinValue;

        public AddInts(int int1, int int2) => Result = int1 + int2;
    }
}
```

<img src=".NetFramework Image/3.PNG" width="70%">
</td>
</tr>

<tr>
<td>
3
</td>
<td>
프로젝트를 Release 모드로 빌드한다
</td>
<td>
<img src=".NetFramework Image/4.PNG" width="70%">
</td>
</tr>
</table>

<br>

## 4. 매니페스트 생성 (*.nuspec)

<br>

- NuGet CLI를 이용하여 *.nuspec 파일을 생성한다.

<br>

<table>
<tr>
<th>
순서
</th>
<th>
내용
</th>
<th>
비고
</th>
</tr>

<tr>
<td>
1
</td>
<td>
명령 프롬프트를 실행한다
</td>
<td>
<img src=".NetFramework Image/5.PNG" width="70%">
</td>
</tr>

<tr>
<td>
2
</td>
<td>
프로젝트 경로로 이동한다
</td>
<td>

경로 이동 방법 : `cd {폴더 경로}`
<img src=".NetFramework Image/6.PNG" width="90%">

</td>
</tr>

<tr>
<td>
3
</td>
<td>
*.nuspec 생성 명령을 실행한다.<br>
작업이 정상적으로 수행되었다면, {프로젝트 파일 이름.nuspec}이(가) 생성되었습니다. 라는 메세지가 출력된다.
</td>
<td>

명령어 : `nuget spec {프로젝트 파일 이름}`
<img src=".NetFramework Image/7.PNG" width="90%">

</td>
</tr>
</table>

<br>

## 5. 매니페스트 작성

<br>

- ***중요한 부분*** 이다. 생성된 .nuspec 파일에 작성한 정보가 NuGet에 등록정보로 올라간다.
- 아래는 샘플 파일 및 설명이다.

<br>

### 5.1. Sample.nuspec

<br>

```xml
<?xml version="1.0" encoding="utf-8"?>
<package>
  <metadata>
    <id>$id$</id>
    <version>1.0.0</version>
    <authors>$author$</authors>
    <description>
        NModbus4.Wrapper is driven from NModbus4 for integrated usage.
        Difference of NModbus4.Wrapper from NModbus4 is: 

        1. integrate class (RTU, TCP, UDP...) into ModbusService
        2. support C# data types (bool, int, float)
        3. support threading when using Client

        - GitHub : https://github.com/peponi-paradise/NModbus4.Wrapper
        - Blog : https://peponi-paradise.tistory.com
    </description>
    <requireLicenseAcceptance>true</requireLicenseAcceptance>
    <license type="file">LICENSE.md</license>
    <readme>README.md</readme>
    <!-- <icon>icon.png</icon> -->
    <projectUrl>
        https://github.com/peponi-paradise/NModbus4.Wrapper
    </projectUrl>
    <releaseNotes>
        Version 1.0.0:
            First release
    </releaseNotes>
    <copyright>$copyright$</copyright>
    <tags>Modbus NModbus4 Wrapper</tags>
    <dependencies>
      <group targetFramework=".NETFramework4.7.2">
        <dependency id="NModbus4" version="2.1.0"/>
      </group>
    </dependencies>
  </metadata>
  <files>
    <file src="..\LICENSE.md" target=""/>
    <file src="..\README.md" target=""/>
  </files>
</package>
```

<br>

### 5.2. Sample 항목 설명

<br>


1. 필수 항목
    |항목|내용|비고|
    |:---:|---|---|
    |id|NuGet에서 검색할 때 나오는 패키지 이름|`$id$` : 프로젝트 이름|
    |version|패키지 버전|`$version$` : 어셈블리 버전|
    |authors|작성자|`$author$` : 어셈블리 정보의 회사와 동일|
    |description|패키지 설명||

<br>

2. 선택 항목
    |항목|내용|비고|
    |:---:|---|---|
    |requireLicenseAcceptance|라이선스 동의 메시지 팝업 여부||
    |license|라이선스 유형 또는 파일 입력||
    |readme|README 파일이 있을 경우 등록||
    |icon|아이콘 등록||
    |projectUrl|패키지의 홈페이지 등록|[repository](https://learn.microsoft.com/ko-kr/nuget/reference/nuspec#repository)를 사용하는 경우도 있음|
    |releaseNotes|릴리즈의 정보||
    |copyright|저작권 정보|`$copyright$` : 어셈블리 정보의 저작권|
    |tags|패키지 검색 시 사용. ` ` (띄어쓰기)로 구분||
    |dependencies|종속성 정보 등록|[Dependencies 요소](https://learn.microsoft.com/ko-kr/nuget/reference/nuspec#dependencies-element) 참조|
    |files|첨부 파일 등록|

<br>

## 6. 패키지 생성

<br>

- 작성한 *.nuspec 파일을 이용하여 NuGet 패키지를 생성한다.
- 명령어 : `nuget pack -IncludeReferencedProjects -properties Configuration=Release`
- 동작이 제대로 된 경우 `{id}.{version}.nupkg` 파일이 생성된다.
    <img src=".NetFramework Image/8.PNG" width="60%">

<br>

## 7. 패키지 배포

- [소개글](#1-소개글)에서 소개한 것처럼 NuGet 테스트 사이트와 공식 사이트를 이용하는 방법은 동일하다.
- 필요에 따라 
    1. 테스트 사이트에서 먼저 테스트를 수행한 후 업로드 또는
    2. 바로 NuGet 공식 사이트에 업로드한다.

<br>

### 7.1. NuGet API 키 얻기

<br>

|번호|내용|비고|
|:---:|---|---|
|1|NuGet 홈페이지 우측 상단의 `유저 이름`을 클릭한 후, `API Keys`를 클릭한다|<img src=".NetFramework Image/9.PNG" width="80%">|
|2|`Key Name` 및 `Glob Pattern` 정보를 입력 후, `Create`를 수행한다|<img src=".NetFramework Image/10.PNG" width="80%">|
|3|`Manage` 항목에 생성된 Key를 찾아 `Copy` 클릭|<img src=".NetFramework Image/11.PNG" width="80%">|
|주의사항|API Key는 본인을 제외한 누구도 알면 안됩니다|본인도 모르는 것이 좋을지도..|

<br>

### 7.2. Nuget 패키지 업로드

<br>

- 다음 명령을 실행하여 생성된 패키지를 업로드한다.
    
    |Upload target|Command|
    |---|---|
    |NuGet official|`nuget push <package filename> <api key value> -Source https://nuget.org/api/v2/package`|
    |NuGet test|`nuget push <package filename> <api key value> -Source https://int.nugettest.org/api/v2/package`|

- 정상적으로 Push 명령이 수행된 경우 `Your package was pushed`라는 메세지가 확인되며 작업이 끝난다.

<br>