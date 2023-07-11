<?xml version="1.0" encoding="utf-8"?>
<!DOCTYPE xsl:stylesheet [
	<!ENTITY cr "<xsl:text>
</xsl:text>">
]>
<xsl:stylesheet
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0"
	xmlns:tt="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	>
	<xsl:output method="text" indent="no"/>

	
	    <!--
		
		 <UnitTestResult executionId="bd0c9f5e-a54a-4f38-b5ba-02e5f653a0c5"
     testId="4921d2de-4fc9-a1f6-942a-be92da908484" 
     testName="ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)" 
     computerName="LW-18560"
      duration="00:00:00.0003647"
       startTime="2023-07-06T14:53:50.5981898-04:00" 
       endTime="2023-07-06T14:53:50.5993165-04:00" 
       testType="13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b"
        outcome="Passed" 
        testListId="8c84fa94-04c1-424b-9868-57a2d4851a1d"
         relativeResultsDirectory="bd0c9f5e-a54a-4f38-b5ba-02e5f653a0c5"
          />
		
		<UnitTest 
		name="ToEnumTest (name,name2|test name,WithEnumValue, WithMemberName, WithDisplay)"
		storage="d:\repos\nu2\netapi\framework\eliassen.system.tests\bin\debug\net6.0\eliassen.system.tests.dll" 
		id="4921d2de-4fc9-a1f6-942a-be92da908484">
      <TestCategory>
        <TestCategoryItem TestCategory="Unit" />
      </TestCategory>
      <Execution id="bd0c9f5e-a54a-4f38-b5ba-02e5f653a0c5" />
      <TestMethod 
	  codeBase="D:\Repos\Nu2\NetApi\Framework\Eliassen.System.Tests\bin\Debug\net6.0\Eliassen.System.Tests.dll" 
	  adapterTypeName="executor://mstestadapter/v2" 
	  className="Eliassen.System.Tests.Reflection.EnumExtensionsTests"
	  name="ToEnumTest" 
	  />
    </UnitTest>-->

	<xsl:template match="/">
		<xsl:text># Test Results</xsl:text>&cr;&cr;
		<xsl:apply-templates select="//tt:UnitTestResult"/>
	</xsl:template>
	
	<xsl:template match="tt:UnitTestResult">
		<xsl:variable name="test-id" select="@testId" />
		<xsl:variable name="unit-test" select="/tt:TestDefinitions/tt:UnitTest[@id = $test-id]" />
		<xsl:variable name="unit-test-class" select="$unit-test/tt:TestMethod/@className" />
		<xsl:variable name="unit-test-method" select="$unit-test/tt:TestMethod/@name" />
		
		<xsl:text>## Test: </xsl:text>
		<xsl:value-of select="@testName"/>&cr;	
		<xsl:text>### Class: </xsl:text><xsl:value-of select="$unit-test-class"/>&cr;
		<xsl:text>### Method: </xsl:text><xsl:value-of select="$unit-test-method"/>&cr;
		<xsl:text>---</xsl:text>&cr;
		<xsl:apply-templates mode="duplicate" select="$unit-test" />
	&cr;
	</xsl:template>


	<xsl:template match="@* | node()" mode="duplicate">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()" mode="duplicate"/>
		</xsl:copy>
	</xsl:template>

</xsl:stylesheet>