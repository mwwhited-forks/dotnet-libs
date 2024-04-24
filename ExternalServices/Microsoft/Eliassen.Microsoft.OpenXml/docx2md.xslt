<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
    xmlns:xhtml="http://www.w3.org/1999/xhtml"
    xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
    xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
	xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"
    xmlns:pr="http://schemas.openxmlformats.org/package/2006/relationships"
	xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main"
	xmlns:pic="http://schemas.openxmlformats.org/drawingml/2006/picture"
	xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml"
	xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape"
	xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    exclude-result-prefixes="xs w r pr wp a pic xhtml w14 wps mc"
    version="2.0"
	>
    <xsl:output method="text" />


    <xsl:template match="/w:document/w:body">
        <xsl:apply-templates select="w:p | w:tbl" mode="body" />
    </xsl:template>

    <xsl:template match="w:p" mode="body">
        <xsl:apply-templates select="w:r" mode="paragraph" />
        <xsl:text>&#13;</xsl:text>
    </xsl:template>

    <xsl:template match="w:r" mode="paragraph">
        <xsl:apply-templates select="w:t" mode="paragraph" />
    </xsl:template>

    <xsl:template match="w:t" mode="paragraph">
        <xsl:variable name="style">
            <xsl:value-of select="../../w:pPr/w:pStyle/@w:val"/>
        </xsl:variable>

        <xsl:choose>
            <xsl:when test="$style='Title'">
                <xsl:text>&#13;</xsl:text>
                <xsl:text># </xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>&#13;</xsl:text>
            </xsl:when>
            <xsl:when test="$style='Heading1'">
                <xsl:text>&#13;</xsl:text>
                <xsl:text>## </xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>&#13;</xsl:text>
            </xsl:when>
            <xsl:when test="$style='Heading2'">
                <xsl:text>&#13;</xsl:text>
                <xsl:text>### </xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>&#13;</xsl:text>
            </xsl:when>
            <xsl:when test="$style='Heading3'">
                <xsl:text>&#13;</xsl:text>
                <xsl:text>#### </xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>&#13;</xsl:text>
            </xsl:when>

            <xsl:when test="$style='FootnoteText'">
                <xsl:text>*</xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>* </xsl:text>
            </xsl:when>

            <xsl:when test="$style='ListParagraph'">
                <xsl:variable name="depth" select="../../w:pPr/w:numPr/w:ilvl/@w:val" />
                <xsl:variable name="padding" select="substring('            ', 1,$depth*2)" />

                <xsl:value-of select="$padding"/>
                <xsl:text>* </xsl:text>
                <xsl:value-of select="text()"/>
            </xsl:when>

            <xsl:when test="$style=''">
                <xsl:value-of select="text()"/>
            </xsl:when>
            <xsl:when test="$style='BodyText'">
                <xsl:value-of select="text()"/>
            </xsl:when>
            <xsl:when test="$style='IntenseQuote'">
                <xsl:text>**</xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>** </xsl:text>
            </xsl:when>

            <xsl:otherwise>
                <xsl:text>-----</xsl:text>
                <xsl:value-of select="$style"/>
                <xsl:text>-</xsl:text>
                <xsl:value-of select="text()"/>
                <xsl:text>------</xsl:text>
            </xsl:otherwise>
        </xsl:choose>

        <!--<w:pPr>
			<w:pStyle w:val="Title"/>-->

    </xsl:template>

    <xsl:template match="w:tbl" mode="body">
        <xsl:for-each select="w:tr">
            <xsl:for-each select="w:tc">
                <xsl:text> | </xsl:text>
                <xsl:value-of select="w:p/w:r/w:t"/>
                <!--<xsl:value-of select="descendant::w:t"/>-->
            </xsl:for-each>
            <xsl:text> | </xsl:text>
            <xsl:text>&#13;</xsl:text>

            <xsl:if test="position() = 1">
                <xsl:for-each select="w:tc">
                    <xsl:text> | </xsl:text>
                    <xsl:text> ----- </xsl:text>
                </xsl:for-each>
                <xsl:text> | </xsl:text>
                <xsl:text>&#13;</xsl:text>
            </xsl:if>
        </xsl:for-each>
        <xsl:text>&#13;</xsl:text>

    </xsl:template>

</xsl:stylesheet>