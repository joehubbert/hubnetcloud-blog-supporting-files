CREATE TABLE #CountryTranslationTemp
(
	[CountryId] UNIQUEIDENTIFIER NOT NULL,
	[BCP47LanguageTagCode] NVARCHAR(5) NOT NULL,
	[LocalisedCountryName] NVARCHAR(100) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guadalupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guadalupa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'瓜德罗普',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gwadelupa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'과들루프',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'グアドループ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guadeloupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guadalupe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tanzanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tansania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tansania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'坦桑尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'탄자니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tanzanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'タンザニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tanzania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Tanzânia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Arabie saoudite',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Saudi-Arabien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Arabia Saudí',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Arabia Saudita',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saudi-Arabia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Saudi-Arabia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Saudi-Arabia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Saudiarabien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saudi-Arabien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'沙特阿拉伯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Arabia Saudyjska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'사우디아라비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Saúdská Arábie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サウジアラビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saoedi-Arabië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Arábia Saudita',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Mozambique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mosambik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mozambique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Mozambico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mosambik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mosambik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mosambik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Moçambique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mozambique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'莫桑比克',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mozambik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'모잠비크',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mosambik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モザンビーク',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mozambique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Moçambique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'瓦努阿图',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'바누아투',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バヌアツ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Vanuatu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Lettonie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Lettland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Letonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Lettonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Latvia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Latvia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Latvia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Lettland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Letland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'拉脱维亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Łotwa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'라트비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Lotyšsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ラトビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Letland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Letónia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Île Bouvet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bouvetinsel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Isla Bouvet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isola Bouvet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bouvet’nsaari',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bouvetøya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bouvetøya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bouvetön',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bouvetøen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'布韦岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspa Bouveta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'부베섬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bouvetův ostrov',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブーベ島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bouveteiland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilha Bouvet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Marin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣马力诺',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'산마리노',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サンマリノ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'San Marino',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Marinho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'États fédérés de Micronésie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mikronesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Micronesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Micronesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mikronesian liittovaltio',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mikronesiaføderasjonen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mikronesiaføderasjonen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mikronesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mikronesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'密克罗尼西亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mikronezja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'미크로네시아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mikronésie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ミクロネシア連邦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Micronesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Micronésia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Polynésie française',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Französisch-Polynesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Polinesia Francesa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Polinesia francese',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ranskan Polynesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Fransk Polynesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Fransk Polynesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Franska Polynesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Fransk Polynesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'法属波利尼西亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Polinezja Francuska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'프랑스령 폴리네시아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Francouzská Polynésie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'仏領ポリネシア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Frans-Polynesië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Polinésia Francesa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Maroc',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Marokko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Marruecos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Marocco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Marokko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Marokko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Marokko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Marocko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Marokko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'摩洛哥',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Maroko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'모로코',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Maroko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モロッコ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Marokko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Marrocos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Pakistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴基斯坦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'파키스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Pákistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'パキスタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Pakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Paquistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Jordanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Jordanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Jordania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Giordania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Jordania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Jordan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Jordan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Jordanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Jordan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'约旦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Jordania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'요르단',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jordánsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ヨルダン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Jordanië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Jordânia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Syrie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Syrien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Siria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Siria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Syyria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Syria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Syria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Syrien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Syrien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'叙利亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Syria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'시리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Sýrie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'シリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Syrië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Síria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Serbie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Serbien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Serbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Serbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Serbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Serbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Serbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Serbien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Serbien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'塞尔维亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Serbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세르비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Srbsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セルビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Servië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Sérvia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Timor oriental',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Timor-Leste',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Timor-Leste',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Timor Est',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Itä-Timor',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Timor-Leste (Aust-Timor)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Øst-Timor',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Östtimor',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Timor-Leste',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'东帝汶',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Timor Wschodni',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'동티모르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Východní Timor',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'東ティモール',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Oost-Timor',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Timor-Leste',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿鲁巴',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아루바',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アルバ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Aruba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Suriname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Suriname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Suriname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Suriname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'苏里南',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'수리남',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Surinam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スリナム',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Suriname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Suriname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Gibilterra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'直布罗陀',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'지브롤터',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ジブラルタル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Gibraltar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Finlande',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Finnland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Finlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Finlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Suomi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Finland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Finland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Finland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Finland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'芬兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Finlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'핀란드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Finsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'フィンランド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Finland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Finlândia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Brésil',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Brasilien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Brasil',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Brasile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Brasilia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Brasil',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Brasil',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Brasilien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Brasilien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴西',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Brazylia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'브라질',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Brazílie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブラジル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Brazilië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Brasil',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马里',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'말리',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マリ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Mali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ML'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Turquie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Türkei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Turquía',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Turchia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Turkki',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tyrkia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tyrkia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Turkiet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tyrkiet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'土耳其',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Turcja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'터키',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Turecko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'トルコ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Turkije',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Turquia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Suède',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Schweden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Suecia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Svezia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ruotsi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sverige',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sverige',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sverige',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sverige',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'瑞典',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Szwecja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'스웨덴',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Švédsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スウェーデン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zweden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Suécia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Turques-et-Caïques',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Turks- und Caicosinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Turcas y Caicos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Turks e Caicos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Turks- ja Caicossaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Turks- og Caicosøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Turks- og Caicosøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Turks- och Caicosöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Turks- og Caicosøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'特克斯和凯科斯群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Turks i Caicos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'터크스 케이커스 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Turks a Caicos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'タークス・カイコス諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Turks- en Caicoseilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Turcas e Caicos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'La Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Reunión',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Riunione',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'留尼汪',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Reunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'리유니온',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'レユニオン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Réunion',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Reunião',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Côte d’Ivoire',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Côte d’Ivoire',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Côte d’Ivoire',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Costa d’Avorio',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Norsunluurannikko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Elfenbeinskysten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Elfenbenskysten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Côte d’Ivoire',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Elfenbenskysten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'科特迪瓦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Côte d’Ivoire',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'코트디부아르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Pobřeží slonoviny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'コートジボワール',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Ivoorkust',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Côte d’Ivoire (Costa do Marfim)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Israël',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Israele',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'以色列',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Izrael',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'이스라엘',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Izrael',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'イスラエル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Israël',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Israel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Níger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'尼日尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'니제르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ニジェール',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Niger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Níger',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'哥斯达黎加',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kostaryka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'코스타리카',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kostarika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'コスタリカ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Costa Rica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Grenade',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Granada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'格林纳达',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'그레나다',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'グレナダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Grenada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Granada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Suisse',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Schweiz',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Suiza',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Svizzera',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Sveitsi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sveits',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sveits',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Schweiz',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Schweiz',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'瑞士',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Szwajcaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'스위스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Švýcarsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スイス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zwitserland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Suíça',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Nouvelle-Calédonie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Neukaledonien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Nueva Caledonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Nuova Caledonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Uusi-Kaledonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Ny-Caledonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Ny-Caledonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nya Kaledonien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Ny Kaledonien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'新喀里多尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Nowa Kaledonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'뉴칼레도니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nová Kaledonie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ニューカレドニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nieuw-Caledonië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Nova Caledónia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Île de Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Isle of Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Isla de Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isola di Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mansaari',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Isle of Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Isle of Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马恩岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspa Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'맨 섬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Ostrov Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マン島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Isle of Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilha de Man',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Pérou',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Perú',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Perù',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'秘鲁',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'페루',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ペルー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Peru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Maurice',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mauricio',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'毛里求斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'모리셔스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mauricius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モーリシャス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mauritius',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Maurícia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Trinité-et-Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Trinidad und Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Trinidad y Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Trinidad e Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Trinidad ja Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Trinidad og Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Trinidad og Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Trinidad och Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Trinidad og Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'特立尼达和多巴哥',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Trynidad i Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'트리니다드 토바고',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Trinidad a Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'トリニダード・トバゴ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Trinidad en Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Trindade e Tobago',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Colombie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kolumbien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kolumbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'哥伦比亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kolumbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'콜롬비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kolumbie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'コロンビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Colombia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Colômbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Algérie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Algerien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Argelia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Algeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Algeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Algerie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Algerie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Algeriet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Algeriet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿尔及利亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Algieria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'알제리',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Alžírsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アルジェリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Algerije',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Argélia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bolivie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bolivien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'玻利维亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Boliwia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'볼리비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bolívie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ボリビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bolivia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bolívia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'瑙鲁',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'나우루',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ナウル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Nauru',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Italie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Italien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Italia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Italia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Italia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Italia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Italia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Italien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Italien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'意大利',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Włochy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'이탈리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Itálie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'イタリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Italië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Itália',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Cambodge',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kambodscha',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Camboya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Cambogia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kambodža',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kambodsja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kambodsja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kambodja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Cambodja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'柬埔寨',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kambodża',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'캄보디아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kambodža',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'カンボジア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Cambodja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Camboja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Christophe-et-Niévès',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Kitts und Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'San Cristóbal y Nieves',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Saint Kitts e Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint Kitts ja Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Saint Kitts og Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Saint Kitts og Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'S:t Kitts och Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saint Kitts og Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣基茨和尼维斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Saint Kitts i Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세인트키츠 네비스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatý Kryštof a Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セントクリストファー・ネーヴィス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saint Kitts en Nevis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Cristóvão e Neves',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'France',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Frankreich',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Francia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Francia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ranska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Frankrike',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Frankrike',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Frankrike',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Frankrig',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'法国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Francja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'프랑스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Francie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'フランス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Frankrijk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'França',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Slovénie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Slowenien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Eslovenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Slovenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Slovenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Slovenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Slovenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Slovenien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Slovenien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'斯洛文尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Słowenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'슬로베니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Slovinsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スロベニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Slovenië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Eslovénia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Antigua-et-Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Antigua und Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Antigua y Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Antigua e Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Antigua ja Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Antigua og Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Antigua og Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Antigua och Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Antigua og Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'安提瓜和巴布达',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Antigua i Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'앤티가 바부다',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Antigua a Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アンティグア・バーブーダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Antigua en Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Antígua e Barbuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'乌拉圭',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Urugwaj',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'우루과이',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ウルグアイ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Uruguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Uruguai',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Terres australes françaises',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Französische Süd- und Antarktisgebiete',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Territorios Australes Franceses',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Terre australi francesi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ranskan eteläiset alueet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Dei franske sørterritoria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'De franske sørterritorier',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Franska sydterritorierna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'De Franske Besiddelser i Det Sydlige Indiske Ocean og Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'法属南部领地',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Francuskie Terytoria Południowe i Antarktyczne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'프랑스 남부 지방',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Francouzská jižní území',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'仏領極南諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Franse Gebieden in de zuidelijke Indische Oceaan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Territórios Austrais Franceses',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Corée du Sud',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Südkorea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Corea del Sur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Corea del Sud',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Etelä-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sør-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sør-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sydkorea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sydkorea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'韩国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Korea Południowa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'대한민국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jižní Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'韓国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zuid-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Coreia do Sul',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Vincent-et-les-Grenadines',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Vincent und die Grenadinen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'San Vicente y las Granadinas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Saint Vincent e Grenadine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint Vincent ja Grenadiinit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'St. Vincent og Grenadinane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'St. Vincent og Grenadinene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'S:t Vincent och Grenadinerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saint Vincent og Grenadinerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣文森特和格林纳丁斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Saint Vincent i Grenadyny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세인트빈센트그레나딘',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatý Vincenc a Grenadiny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セントビンセント及びグレナディーン諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saint Vincent en de Grenadines',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Vicente e Granadinas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Philippines',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Philippinen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Filipinas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Filippine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Filippiinit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Filippinane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Filippinene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Filippinerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Filippinerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'菲律宾',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Filipiny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'필리핀',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Filipíny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'フィリピン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Filipijnen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Filipinas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Grèce',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Griechenland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Grecia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Grecia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kreikka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Hellas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Hellas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Grekland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Grækenland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'希腊',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Grecja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'그리스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Řecko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ギリシャ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Griekenland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Grécia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guyane française',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Französisch-Guayana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guayana Francesa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guyana francese',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ranskan Guayana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Fransk Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Fransk Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Franska Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Fransk Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'法属圭亚那',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gujana Francuska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'프랑스령 기아나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Francouzská Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'仏領ギアナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Frans-Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guiana Francesa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Cook',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Cookinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Cook',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Cook',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Cookinsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Cookøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Cookøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Cooköarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Cookøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'库克群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Cooka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'쿡 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Cookovy ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'クック諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Cookeilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Cook',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Salomon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Salomonen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Salomón',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Salomone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Salomonsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Salomonøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Salomonøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Salomonöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Salomonøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'所罗门群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Salomona',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'솔로몬 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Šalamounovy ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ソロモン諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Salomonseilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Salomão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Ukraine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Ukraine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Ucrania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Ucraina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ukraina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Ukraina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Ukraina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Ukraina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Ukraine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'乌克兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Ukraina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'우크라이나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Ukrajina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ウクライナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Oekraïne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ucrânia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sierra Leona',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'塞拉利昂',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'시에라리온',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'シエラレオネ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Sierra Leone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Serra Leoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'汤加',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'통가',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'トンガ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Tonga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Égypte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Ägypten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Egipto',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Egitto',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Egypti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Egypt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Egypt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Egypten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Egypten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'埃及',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Egipt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'이집트',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Egypt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エジプト',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Egypte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Egito',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Cameroun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Camerún',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Camerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Cameroun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'喀麦隆',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'카메룬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kamerun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'カメルーン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kameroen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Camarões',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Cap-Vert',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Cabo Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Cabo Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Capo Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kap Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kapp Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kapp Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kap Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kap Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'佛得角',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Republika Zielonego Przylądka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'카보베르데',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kapverdy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'カーボベルデ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kaapverdië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Cabo Verde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Eswatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Eswatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Esuatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Swaziland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Swazimaa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Swaziland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Eswatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Swaziland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Eswatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'斯威士兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Eswatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'에스와티니',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svazijsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エスワティニ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'eSwatini',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Essuatíni',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Corée du Nord',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nordkorea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Corea del Norte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Corea del Nord',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Pohjois-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nord-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nord-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nordkorea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nordkorea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'朝鲜',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Korea Północna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'북한',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Severní Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'北朝鮮',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Noord-Korea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Coreia do Norte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Irán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'伊朗',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'이란',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Írán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'イラン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Iran',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Irão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Érythrée',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'厄立特里亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Erytrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'에리트리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エリトリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Eritrea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Eritreia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ER'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'关岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'괌',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'グアム',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guame',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Myanmar (Birmanie)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Myanmar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Myanmar (Birmania)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Myanmar (Birmania)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Myanmar (Burma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Myanmar (Burma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Myanmar (Burma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Myanmar (Burma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Myanmar (Burma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'缅甸',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mjanma (Birma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'미얀마',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Myanmar (Barma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ミャンマー (ビルマ)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Myanmar (Birma)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Mianmar (Birmânia)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Omán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿曼',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'오만',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Omán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'オマーン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Oman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Omã',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'OM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tunisie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tunesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Túnez',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Tunisia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tunisia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tunisia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tunisia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tunisien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tunesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'突尼斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tunezja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'튀니지',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tunisko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'チュニジア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tunesië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Tunísia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Congo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kongo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'República Democrática del Congo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Congo - Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kongon demokraattinen tasavalta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kongo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kongo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kongo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Congo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'刚果（金）',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Demokratyczna Republika Konga',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'콩고-킨샤사',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kongo – Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'コンゴ民主共和国(キンシャサ)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Congo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Congo-Kinshasa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Ruanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Ruanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Ruanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ruanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'卢旺达',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'르완다',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ルワンダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Rwanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ruanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Caïmans',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kaimaninseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Caimán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Cayman',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Caymansaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Caymanøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Caymanøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Caymanöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Caymanøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'开曼群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kajmany',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'케이맨 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kajmanské ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ケイマン諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kaaimaneilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Caimão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Papouasie-Nouvelle-Guinée',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Papua-Neuguinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Papúa Nueva Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Papua Nuova Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Papua-Uusi-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Papua Ny-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Papua Ny-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Papua Nya Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Papua Ny Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴布亚新几内亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Papua-Nowa Gwinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'파푸아뉴기니',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Papua-Nová Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'パプアニューギニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Papoea-Nieuw-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Papua-Nova Guiné',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Heard et McDonald',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Heard und McDonaldinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Heard y McDonald',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Heard e McDonald',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Heard ja McDonaldinsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Heardøya og McDonaldøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Heard- og McDonaldøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Heardön och McDonaldöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Heard Island og McDonald Islands',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'赫德岛和麦克唐纳群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Heard i McDonalda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'허드 맥도널드 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Heardův ostrov a McDonaldovy ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ハード島・マクドナルド諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Heard en McDonaldeilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Heard e McDonald',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guinée équatoriale',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Äquatorialguinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guinea Ecuatorial',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guinea Equatoriale',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Päiväntasaajan Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Ekvatorial-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Ekvatorial-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Ekvatorialguinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Ækvatorialguinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'赤道几内亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gwinea Równikowa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'적도 기니',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Rovníková Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'赤道ギニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Equatoriaal-Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guiné Equatorial',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Canada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kanada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Canadá',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Canada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kanada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Canada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Canada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kanada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Canada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'加拿大',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kanada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'캐나다',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kanada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'カナダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Canada',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Canadá',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Moldavie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Republik Moldau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Moldavia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Moldavia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Moldova',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Moldova',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Moldova',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Moldavien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Moldova',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'摩尔多瓦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mołdawia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'몰도바',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Moldavsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モルドバ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Moldavië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Moldávia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Jamaïque',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Jamaika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Giamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Jamaika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'牙买加',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Jamajka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'자메이카',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jamajka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ジャマイカ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Jamaica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'État de la Cité du Vatican',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Vatikanstadt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Ciudad del Vaticano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Città del Vaticano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Vatikaani',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Vatikanstaten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Vatikanstaten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Vatikanstaten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Vatikanstaten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'梵蒂冈',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Watykan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'바티칸 시국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Vatikán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バチカン市国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Vaticaanstad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Cidade do Vaticano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kuuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'古巴',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'쿠바',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'キューバ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Cuba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'越南',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'베트남',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ベトナム',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Vietnam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Vietname',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Fidji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Fidschi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Fiyi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Figi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Fidži',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Fiji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Fiji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Fiji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Fiji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'斐济',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Fidżi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'피지',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Fidži',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'フィジー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Fiji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Fiji',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Barbade',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴巴多斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'바베이도스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バルバドス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Barbados',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Zambie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Sambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'赞比亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'잠비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Zambie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ザンビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Zâmbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Pologne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Polen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Polonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Polonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Puola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Polen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Polen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Polen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Polen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'波兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Polska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'폴란드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Polsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ポーランド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Polen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Polónia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Taïwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Taiwán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'台湾',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tajwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'대만',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tchaj-wan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'台湾',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Taiwan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Espagne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Spanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'España',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Spagna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Espanja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Spania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Spania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Spanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Spanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'西班牙',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Hiszpania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'스페인',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Španělsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スペイン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Spanje',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Espanha',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ES'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Belice',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'伯利兹',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'벨리즈',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ベリーズ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Belize',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Féroé',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Färöer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Feroe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Fær Øer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Färsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Færøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Færøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Färöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Færøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'法罗群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Owcze',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'페로 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Faerské ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'フェロー諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Faeröer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Faroé',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Koweït',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kuwait',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'科威特',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kuwejt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'쿠웨이트',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kuvajt',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'クウェート',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Koeweit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Koweit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'R.A.S. chinoise de Hong Kong',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sonderverwaltungsregion Hongkong',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'RAE de Hong Kong (China)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'RAS di Hong Kong',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Hongkong – Kiinan e.h.a.',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Hongkong S.A.R. Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Hongkong S.A.R. Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Hongkong',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'SAR Hongkong',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'中国香港特别行政区',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'SRA Hongkong (Chiny)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'홍콩(중국 특별행정구)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Hongkong – ZAO Číny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'中華人民共和国香港特別行政区',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Hongkong SAR van China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Hong Kong, RAE da China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Inde',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Indien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'India',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'India',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Intia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'India',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'India',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Indien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Indien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'印度',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Indie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'인도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Indie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'インド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'India',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Índia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'多哥',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'토고',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'トーゴ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Togo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bulgarie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bulgarien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bulgaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bulgaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bulgaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bulgaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bulgaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bulgarien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bulgarien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'保加利亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bułgaria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'불가리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bulharsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブルガリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bulgarije',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bulgária',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Malaui',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马拉维',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'말라위',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マラウイ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Malawi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Maláui',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'布隆迪',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'부룬디',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブルンジ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Burundi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Botsuana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Botsuana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'博茨瓦纳',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'보츠와나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ボツワナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Botswana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Botsuana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'基里巴斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'키리바시',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'キリバス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kiribati',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Quiribáti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'安哥拉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'앙골라',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アンゴラ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Angola',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'尼加拉瓜',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Nikaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'니카라과',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nikaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ニカラグア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nicaragua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Nicarágua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Mexique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mexiko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'México',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Messico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Meksiko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mexico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mexico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mexiko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mexico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'墨西哥',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Meksyk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'멕시코',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mexiko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'メキシコ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mexico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'México',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guinée',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'几内亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gwinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'기니',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guinea',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ギニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guinee',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guiné',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Andorre',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'安道尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Andora',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'안도라',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アンドラ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Andorra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'République dominicaine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Dominikanische Republik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'República Dominicana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Repubblica Dominicana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Dominikaaninen tasavalta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Den dominikanske republikken',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Den dominikanske republikk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Dominikanska republiken',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Den Dominikanske Republik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'多米尼加共和国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Dominikana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'도미니카 공화국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Dominikánská republika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ドミニカ共和国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Dominicaanse Republiek',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'República Dominicana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Azerbaïdjan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Aserbaidschan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Azerbaiyán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Azerbaigian',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Azerbaidžan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Aserbajdsjan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Aserbajdsjan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Azerbajdzjan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Aserbajdsjan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿塞拜疆',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Azerbejdżan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아제르바이잔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Ázerbájdžán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アゼルバイジャン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Azerbeidzjan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Azerbaijão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bhoutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bután',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'不丹',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'부탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bhútán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブータン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bhutan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Butão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'纽埃',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'니우에',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ニウエ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Niue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Niuê',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Autriche',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Österreich',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Austria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Austria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Itävalta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Austerrike',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Østerrike',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Österrike',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Østrig',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'奥地利',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Austria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'오스트리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Rakousko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'オーストリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Oostenrijk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Áustria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Somalie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'索马里',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Somalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'소말리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Somálsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ソマリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Somalië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Somália',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'萨摩亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'사모아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サモア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Croatie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kroatien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Croacia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Croazia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kroatia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kroatia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kroatia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kroatien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kroatien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'克罗地亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Chorwacja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'크로아티아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Chorvatsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'クロアチア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kroatië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Croácia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Chili',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Cile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'智利',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'칠레',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'チリ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Chili',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Chile',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guinée-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guinea-Bisáu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'几内亚比绍',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gwinea Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'기니비사우',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guinea-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ギニアビサウ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guinee-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guiné-Bissau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Vierges des États-Unis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Amerikanische Jungferninseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Vírgenes de EE. UU.',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Vergini Americane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Yhdysvaltain Neitsytsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Dei amerikanske Jomfruøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'De amerikanske jomfruøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Amerikanska Jungfruöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'De Amerikanske Jomfruøer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'美属维尔京群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Dziewicze Stanów Zjednoczonych',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'미국령 버진아일랜드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Americké Panenské ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'米領ヴァージン諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Amerikaanse Maagdeneilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Virgens dos EUA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Macédoine du Nord',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nordmazedonien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Macedonia del Norte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Macedonia del Nord',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Pohjois-Makedonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nord-Makedonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nord-Makedonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nordmakedonien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nordmakedonien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'北马其顿',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Macedonia Północna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'북마케도니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Severní Makedonie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'北マケドニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Noord-Macedonië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Macedónia do Norte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Albanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Albanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Albania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Albania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Albania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Albania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Albania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Albanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Albanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿尔巴尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Albania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'알바니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Albánie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アルバニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Albanië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Albânia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'泽西岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'저지',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ジャージー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Jersey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Pierre-et-Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Pierre und Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'San Pedro y Miquelón',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Saint-Pierre e Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint-Pierre ja Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Saint-Pierre-et-Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Saint-Pierre-et-Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'S:t Pierre och Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saint Pierre og Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣皮埃尔和密克隆群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Saint-Pierre i Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'생피에르 미클롱',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Saint-Pierre a Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サンピエール島・ミクロン島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saint-Pierre en Miquelon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Pedro e Miquelão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Soudan du Sud',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Südsudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sudán del Sur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sud Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Etelä-Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sør-Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sør-Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sydsudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sydsudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'南苏丹',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Sudan Południowy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'남수단',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jižní Súdán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'南スーダン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zuid-Soedan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Sudão do Sul',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Ouganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'乌干达',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'우간다',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ウガンダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Oeganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Uganda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bermudes',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bermudas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'百慕大',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bermudy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'버뮤다',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bermudy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バミューダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bermuda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bermudas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'托克劳',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'토켈라우',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'トケラウ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tokelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Toquelau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Panamá',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Panamá',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴拿马',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'파나마',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'パナマ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Panama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Panamá',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Turkménistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Turkmenistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'土库曼斯坦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'투르크메니스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Turkmenistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'トルクメニスタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Turkmenistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Turquemenistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Groenland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Grönland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Groenlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Groenlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Grönlanti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Grønland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Grønland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Grönland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Grønland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'格陵兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Grenlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'그린란드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Grónsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'グリーンランド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Groenland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Gronelândia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Malaisie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Malaysia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Malasia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Malaysia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Malesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Malaysia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Malaysia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Malaysia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Malaysia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马来西亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Malezja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'말레이시아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Malajsie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マレーシア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Maleisië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Malásia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'蒙特塞拉特',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'몬트세라트',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モントセラト',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Montserrat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Monserrate',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Danemark',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Dänemark',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Dinamarca',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Danimarca',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tanska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Danmark',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Danmark',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Danmark',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Danmark',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'丹麦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Dania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'덴마크',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Dánsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'デンマーク',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Denemarken',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Dinamarca',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'洪都拉斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'온두라스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ホンジュラス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Honduras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tchad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tschad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Chad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Ciad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tšad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tsjad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tsjad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tchad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tchad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'乍得',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Czad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'차드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Čad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'チャド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tsjaad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Chade',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Allemagne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Deutschland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Alemania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Germania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saksa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tyskland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tyskland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tyskland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tyskland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'德国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Niemcy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'독일',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Německo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ドイツ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Duitsland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Alemanha',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Comores',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Komoren',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Comoras',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Comore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Komorit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Komorane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Komorene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Komorerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Comorerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'科摩罗',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Komory',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'코모로',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Komory',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'コモロ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Comoren',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Comores',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Palaos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Palaos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'帕劳',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'팔라우',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'パラオ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Palau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bahama',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bahamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴哈马',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bahamy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'바하마',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bahamy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バハマ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bahama’s',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Baamas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Slovaquie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Slowakei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Eslovaquia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Slovacchia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Slovakia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Slovakia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Slovakia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Slovakien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Slovakiet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'斯洛伐克',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Słowacja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'슬로바키아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Slovensko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スロバキア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Slowakije',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Eslováquia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Martin (partie néerlandaise)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'荷属圣马丁',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Sint Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'신트마르턴',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatý Martin (Nizozemsko)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'シント・マールテン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Sint-Maarten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Martinho (Sint Maarten)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Gambie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'冈比亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'감비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Gambie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ガンビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Gambia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Gâmbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Liban',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Líbano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Libano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'黎巴嫩',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Liban',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'레바논',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'レバノン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Libanon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Líbano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Portogallo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Portugali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'葡萄牙',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Portugalia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'포르투갈',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Portugalsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ポルトガル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Portugal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tadjikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tadschikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Tayikistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Tagikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tadžikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tadsjikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tadsjikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tadzjikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tadsjikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'塔吉克斯坦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tadżykistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'타지키스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tádžikistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'タジキスタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tadzjikistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Tajiquistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Territoire britannique de l’océan Indien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Britisches Territorium im Indischen Ozean',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Territorio Británico del Océano Índico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Territorio britannico dell’Oceano Indiano',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Brittiläinen Intian valtameren alue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Det britiske territoriet I Indiahavet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Det britiske territoriet i Indiahavet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Brittiska territoriet i Indiska oceanen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Det Britiske Territorium i Det Indiske Ocean',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'英属印度洋领地',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Brytyjskie Terytorium Oceanu Indyjskiego',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'영국령 인도양 식민지',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Britské indickooceánské území',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'英領インド洋地域',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Brits Indische Oceaanterritorium',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Território Britânico do Oceano Índico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Royaume-Uni',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Vereinigtes Königreich',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Reino Unido',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Regno Unito',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Iso-Britannia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Storbritannia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Storbritannia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Storbritannien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Storbritannien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'英国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wielka Brytania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'영국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Spojené království',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'イギリス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Verenigd Koninkrijk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Reino Unido',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GB'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Japon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Japan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Japón',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Giappone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Japani',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Japan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Japan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Japan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Japan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'日本',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Japonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'일본',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Japonsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'日本',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Japan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Japão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'JP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'San Martín',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Saint Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint-Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Saint Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Saint-Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Saint-Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saint Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'法属圣马丁',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Saint-Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'생마르탱',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatý Martin (Francie)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サン・マルタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saint-Martin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Martinho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Islande',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Islanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Islanti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'冰岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Islandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아이슬란드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アイスランド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'IJsland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Islândia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Pitcairninseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Pitcairnøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Pitcairnöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'皮特凯恩群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'핏케언 섬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Pitcairnovy ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ピトケアン諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Pitcairneilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Pitcairn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Roumanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Rumänien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Rumanía',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Romania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Romania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Romania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Romania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Rumänien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Rumænien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'罗马尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Rumunia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'루마니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Rumunsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ルーマニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Roemenië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Roménia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Nigéria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'尼日利亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'나이지리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nigérie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ナイジェリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nigeria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Nigéria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Pays-Bas caribéens',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bonaire, Sint Eustatius und Saba',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Caribe neerlandés',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Caraibi olandesi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Karibian Alankomaat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Karibisk Nederland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Karibisk Nederland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Karibiska Nederländerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'De tidligere Nederlandske Antiller',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'荷属加勒比区',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Niderlandy Karaibskie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'네덜란드령 카리브',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Karibské Nizozemsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'オランダ領カリブ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Caribisch Nederland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Países Baixos Caribenhos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Simbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Zimbabue',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'津巴布韦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'짐바브웨',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ジンバブエ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zimbabwe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Zimbabué',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马约特',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Majotta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'마요트',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マヨット',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mayotte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Maiote',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sainte-Lucie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Santa Lucía',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Saint Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'St. Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'St. Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'S:t Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saint Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣卢西亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Saint Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세인트루시아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatá Lucie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セントルシア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saint Lucia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Santa Lúcia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Pays-Bas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Niederlande',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Países Bajos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Paesi Bassi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Alankomaat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nederland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nederland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nederländerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Holland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'荷兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Holandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'네덜란드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nizozemsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'オランダ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nederland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Países Baixos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Afganistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Afganistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿富汗',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Afganistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아프가니스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Afghánistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アフガニスタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Afghanistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Afeganistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Émirats arabes unis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Vereinigte Arabische Emirate',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Emiratos Árabes Unidos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Emirati Arabi Uniti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Arabiemiirikunnat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Dei sameinte arabiske emirata',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'De forente arabiske emirater',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Förenade Arabemiraten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'De Forenede Arabiske Emirater',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿拉伯联合酋长国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Zjednoczone Emiraty Arabskie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아랍에미리트',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Spojené arabské emiráty',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アラブ首長国連邦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Verenigde Arabische Emiraten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Emirados Árabes Unidos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Norvège',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Norwegen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Noruega',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Norvegia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Norja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Noreg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Norge',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Norge',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Norge',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'挪威',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Norwegia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'노르웨이',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Norsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ノルウェー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Noorwegen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Noruega',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Libéria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'利比里亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'라이베리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Libérie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'リベリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Liberia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Libéria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Haïti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Haití',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'海地',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아이티',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ハイチ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Haïti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Haiti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Russie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Russland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Rusia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Russia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Venäjä',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Russland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Russland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Ryssland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Rusland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'俄罗斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Rosja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'러시아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Rusko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ロシア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Rusland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Rússia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'RU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Gabun',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Gabón',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'加蓬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'가봉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ガボン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Gabon',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Gabão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Porto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Portorico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'波多黎各',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Portoryko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'푸에르토리코',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Portoriko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'プエルトリコ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Puerto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Porto Rico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bosnie-Herzégovine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bosnien und Herzegowina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bosnia y Herzegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bosnia ed Erzegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bosnia ja Hertsegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bosnia-Hercegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bosnia-Hercegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bosnien och Hercegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bosnien-Hercegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'波斯尼亚和黑塞哥维那',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bośnia i Hercegowina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'보스니아 헤르체고비나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bosna a Hercegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ボスニア・ヘルツェゴビナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bosnië en Herzegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bósnia e Herzegovina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Malouines',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Falklandinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Malvinas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Falkland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Falklandinsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Falklandsøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Falklandsøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Falklandsöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Falklandsøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'福克兰群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Falklandy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'포클랜드 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Falklandské ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'フォークランド諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Falklandeilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Malvinas (Falkland)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'FK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Iraq',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'伊拉克',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'이라크',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Irák',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'イラク',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Irak',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Iraque',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Afrique du Sud',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Südafrika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sudáfrica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sudafrica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Etelä-Afrikka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sør-Afrika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sør-Afrika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sydafrika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sydafrika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'南非',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Republika Południowej Afryki',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'남아프리카',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jihoafrická republika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'南アフリカ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zuid-Afrika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'África do Sul',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ZA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bénin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Benín',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'贝宁',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'베냉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ベナン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Benin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Benim',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bahreïn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bahrain',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Baréin',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bahrein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bahrain',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bahrain',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bahrain',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bahrain',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bahrain',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴林',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bahrajn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'바레인',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bahrajn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バーレーン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bahrein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Barém',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Équateur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'厄瓜多尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Ekwador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'에콰도르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Ekvádor',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エクアドル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Ecuador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Equador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴拉圭',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Paragwaj',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'파라과이',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'パラグアイ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Paraguay',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Paraguai',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Hongrie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Ungarn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Hungría',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Ungheria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Unkari',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Ungarn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Ungarn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Ungern',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Ungarn',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'匈牙利',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Węgry',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'헝가리',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Maďarsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ハンガリー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Hongarije',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Hungria',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'HU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'萨尔瓦多',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Salwador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'엘살바도르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エルサルバドル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'El Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Salvador',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Île Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Norfolkinsel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Isla Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isola Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Norfolkinsaari',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Norfolkøya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Norfolkøya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Norfolkön',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Norfolk Island',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'诺福克岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'노퍽섬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ノーフォーク島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilha Norfolk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Namibie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'纳米比亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Namibia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'나미비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Namibie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ナミビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Namibië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Namíbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'nan'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Yémen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Yemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Yemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Yemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'也门',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'예멘',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'イエメン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Jemen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Iémen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'YE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Territoires palestiniens',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Palästinensische Autonomiegebiete',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Territorios Palestinos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Territori palestinesi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Palestiinalaisalueet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Palestinsk territorium',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Det palestinske området',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Palestinska territorierna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'De palæstinensiske områder',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'巴勒斯坦领土',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Terytoria Palestyńskie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'팔레스타인 지구',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Palestinská území',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'パレスチナ自治区',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Palestijnse gebieden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Territórios palestinianos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'PS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Monténégro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'黑山',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Czarnogóra',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'몬테네그로',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Černá Hora',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モンテネグロ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Montenegro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ME'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Australie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Australien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Australia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Australia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Australia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Australia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Australia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Australien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Australien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'澳大利亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Australia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'오스트레일리아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Austrálie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'オーストラリア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Australië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Austrália',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Malte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马耳他',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'몰타',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マルタ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Malta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tchéquie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tschechien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Chequia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Cechia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tšekki',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tsjekkia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tsjekkia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tjeckien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tjekkiet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'捷克',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Czechy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'체코',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Česko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'チェコ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tsjechië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Chéquia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sénégal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'塞内加尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세네갈',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セネガル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Senegal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Indonésie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Indonesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Indonesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Indonesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Indonesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Indonesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Indonesia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Indonesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Indonesien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'印度尼西亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Indonezja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'인도네시아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Indonésie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'インドネシア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Indonesië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Indonésia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ID'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Estonie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Estland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Estonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Estonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Viro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Estland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Estland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Estland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Estland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'爱沙尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Estonia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'에스토니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Estonsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エストニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Estland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Estónia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Singapour',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Singapur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Singapur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'新加坡',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Singapur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'싱가포르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Singapur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'シンガポール',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Singapore',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Singapura',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Samoa américaines',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Amerikanisch-Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Samoa Americana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Samoa americane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Amerikan Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Amerikansk Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Amerikansk Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Amerikanska Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Amerikansk Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'美属萨摩亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Samoa Amerykańskie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아메리칸 사모아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Americká Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'米領サモア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Amerikaans-Samoa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Samoa Americana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Belgique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Belgien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bélgica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Belgio',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Belgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Belgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Belgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Belgien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Belgien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'比利时',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Belgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'벨기에',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Belgie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ベルギー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'België',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bélgica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Anguila',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'安圭拉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'앵귈라',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アンギラ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Anguilla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Anguila',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Géorgie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Georgien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Georgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Georgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Georgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Georgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Georgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Georgien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Georgien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'格鲁吉亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gruzja',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'조지아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Gruzie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ジョージア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Georgië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Geórgia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Mariannes du Nord',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nördliche Marianen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Marianas del Norte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Marianne settentrionali',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Pohjois-Mariaanit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nord-Marianane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nord-Marianene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nordmarianerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nordmarianerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'北马里亚纳群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mariany Północne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'북마리아나제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Severní Mariany',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'北マリアナ諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Noordelijke Marianen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Marianas do Norte',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Biélorussie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Belarus',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bielorrusia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bielorussia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Valko-Venäjä',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kviterussland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Hviterussland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Vitryssland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Hviderusland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'白俄罗斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Białoruś',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'벨라루스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bělorusko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ベラルーシ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Belarus',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bielorrússia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Mauritanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mauretanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mauritania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Mauritania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mauritania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mauritania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mauritania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mauretanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mauretanien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'毛里塔尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mauretania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'모리타니',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mauritánie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モーリタニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mauritanië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Mauritânia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Mongolie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Mongolei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mongolia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Mongolia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Mongolia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Mongolia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Mongolia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Mongoliet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Mongoliet',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'蒙古',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Mongolia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'몽골',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Mongolsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モンゴル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Mongolië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Mongólia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sao Tomé-et-Principe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'São Tomé und Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Santo Tomé y Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'São Tomé e Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'São Tomé ja Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'São Tomé og Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'São Tomé og Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'São Tomé och Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'São Tomé og Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣多美和普林西比',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Świętego Tomasza i Książęca',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'상투메 프린시페',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatý Tomáš a Princův ostrov',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サントメ・プリンシペ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Sao Tomé en Principe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Tomé e Príncipe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ST'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Arménie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Armenien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Armenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Armenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Armenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Armenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Armenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Armenien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Armenien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'亚美尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Armenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아르메니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Arménie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アルメニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Armenië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Arménia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'布基纳法索',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'부르키나파소',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブルキナファソ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Burkina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Burquina Faso',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guernesey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'根西岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'건지',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ガーンジー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guernsey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guernesey',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Dschibuti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Yibuti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Gibuti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'吉布提',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Dżibuti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'지부티',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Džibutsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ジブチ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Djibouti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Jibuti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'危地马拉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gwatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'과테말라',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'グアテマラ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guatemala',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Irlande',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Irland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Irlanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Irlanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Irlanti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Irland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Irland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Irland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Irland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'爱尔兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Irlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아일랜드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Irsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アイルランド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Ierland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Irlanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'IE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'République centrafricaine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Zentralafrikanische Republik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'República Centroafricana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Repubblica Centrafricana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Keski-Afrikan tasavalta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Den sentralafrikanske republikken',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Den sentralafrikanske republikk',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Centralafrikanska republiken',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Den Centralafrikanske Republik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'中非共和国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Republika Środkowoafrykańska',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'중앙 아프리카 공화국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Středoafrická republika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'中央アフリカ共和国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Centraal-Afrikaanse Republiek',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'República Centro-Africana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Île Christmas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Weihnachtsinsel',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Isla de Navidad',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isola Christmas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Joulusaari',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Christmasøya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Christmasøya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Julön',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Juleøen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣诞岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspa Bożego Narodzenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'크리스마스섬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Vánoční ostrov',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'クリスマス島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Christmaseiland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilha do Natal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CX'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Kirghizistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kirgisistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Kirguistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Kirghizistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kirgisia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kirgisistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kirgisistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kirgizistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kirgisistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'吉尔吉斯斯坦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kirgistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'키르기스스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kyrgyzstán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'キルギス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kirgizië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Quirguistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Madagascar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Madagascar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Madagascar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马达加斯加',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'마다가스카르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マダガスカル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Madagaskar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Madagáscar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Lituanie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Litauen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Lituania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Lituania',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Liettua',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Litauen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Litauen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Litauen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Litauen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'立陶宛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Litwa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'리투아니아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Litva',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'リトアニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Litouwen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Lituânia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LT'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Bangladesch',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Bangladés',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'孟加拉国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Bangladesz',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'방글라데시',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Bangladéš',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'バングラデシュ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Bangladesh',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Bangladeche',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'图瓦卢',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'투발루',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ツバル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Tuvalu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Soudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sudán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'苏丹',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Sudan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'수단',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Súdán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スーダン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Soedan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Sudão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SD'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'列支敦士登',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'리히텐슈타인',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Lichtenštejnsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'リヒテンシュタイン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Liechtenstein',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Listenstaine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LI'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Ouzbékistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Usbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Uzbekistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Uzbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Uzbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Usbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Usbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Uzbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Usbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'乌兹别克斯坦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Uzbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'우즈베키스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Uzbekistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ウズベキスタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Oezbekistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Usbequistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Thaïlande',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Thailand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Tailandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Thailandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Thaimaa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Thailand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Thailand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Thailand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Thailand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'泰国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Tajlandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'태국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Thajsko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'タイ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Thailand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Tailândia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'TH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'老挝',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'라오스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ラオス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Laos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Libye',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Libyen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Libia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Libia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Libya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Libya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Libya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Libyen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Libyen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'利比亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Libia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'리비아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Libye',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'リビア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Libië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Líbia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Brunéi Darussalam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Brunei Darussalam',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Brunéi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'文莱',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'브루나이',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Brunej',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ブルネイ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Brunei',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Cocos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kokosinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Cocos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Cocos (Keeling)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kookossaaret (Keelingsaaret)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kokosøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kokosøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kokosöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Cocosøerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'科科斯（基林）群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Kokosowe',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'코코스 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kokosové ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ココス(キーリング)諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Cocoseilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas dos Cocos (Keeling)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Vierges britanniques',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Britische Jungferninseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Vírgenes Británicas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Vergini Britanniche',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Brittiläiset Neitsytsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Dei britiske Jomfruøyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'De britiske jomfruøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Brittiska Jungfruöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'De Britiske Jomfruøer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'英属维尔京群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Brytyjskie Wyspy Dziewicze',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'영국령 버진아일랜드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Britské Panenské ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'英領ヴァージン諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Britse Maagdeneilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Virgens Britânicas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sahara occidental',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Westsahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sáhara Occidental',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sahara occidentale',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Länsi-Sahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Vest-Sahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Vest-Sahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Västsahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Vestsahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'西撒哈拉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Sahara Zachodnia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'서사하라',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Západní Sahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'西サハラ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Westelijke Sahara',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Sara Ocidental',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'EH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Géorgie du Sud et îles Sandwich du Sud',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Südgeorgien und die Südlichen Sandwichinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Georgia del Sur y Sandwich del Sur',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Georgia del Sud e Sandwich australi',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Etelä-Georgia ja Eteläiset Sandwichsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sør-Georgia og Sør-Sandwichøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sør-Georgia og Sør-Sandwichøyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sydgeorgien och Sydsandwichöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'South Georgia og De Sydlige Sandwichøer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'南乔治亚和南桑威奇群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Georgia Południowa i Sandwich Południowy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'사우스조지아 사우스샌드위치 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Jižní Georgie a Jižní Sandwichovy ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サウスジョージア・サウスサンドウィッチ諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Zuid-Georgia en Zuidelijke Sandwicheilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Geórgia do Sul e Sandwich do Sul',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Maldives',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Malediven',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Maldivas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Maldive',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Malediivit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Maldivane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Maldivene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Maldiverna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Maldiverne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马尔代夫',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Malediwy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'몰디브',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Maledivy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モルディブ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Maldiven',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Maldivas',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MV'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Congo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kongo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Congo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Congo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kongon tasavalta',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kongo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kongo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kongo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Congo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'刚果（布）',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kongo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'콩고-브라자빌',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kongo – Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'コンゴ共和国(ブラザビル)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Congo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Congo-Brazzaville',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CG'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Chine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Cina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kiina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'中国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Chiny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'중국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Čína',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'中国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CN'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Katar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Catar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'卡塔尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Katar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'카타르',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Katar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'カタール',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Qatar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Catar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'QA'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'委内瑞拉',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wenezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'베네수엘라',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ベネズエラ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Venezuela',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'VE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圭亚那',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Gujana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'가이아나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ガイアナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Guyana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Guiana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Lesoto',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'莱索托',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'레소토',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'レソト',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Lesotho',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Lesoto',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LS'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Kenya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Kenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Kenya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kenya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kenya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kenya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kenya',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'肯尼亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'케냐',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Keňa',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ケニア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kenia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Quénia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KE'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'斯里兰卡',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'스리랑카',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Srí Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スリランカ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Sri Lanka',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Sri Lanca',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LK'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles mineures éloignées des États-Unis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Amerikanische Überseeinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas menores alejadas de EE. UU.',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Altre isole americane del Pacifico',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Yhdysvaltain erillissaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'USAs ytre småøyar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'USAs ytre øyer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'USA:s yttre öar',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Amerikanske oversøiske øer',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'美国本土外小岛屿',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Dalekie Wyspy Mniejsze Stanów Zjednoczonych',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'미국령 해외 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Menší odlehlé ostrovy USA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'合衆国領有小離島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kleine afgelegen eilanden van de Verenigde Staten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Menores Afastadas dos EUA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'UM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Wallis-et-Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Wallis und Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Wallis y Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Wallis e Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Wallis ja Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Wallis og Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Wallis og Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Wallis- och Futunaöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Wallis og Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'瓦利斯和富图纳',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wallis i Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'왈리스-푸투나 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Wallis a Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ウォリス・フツナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Wallis en Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Wallis e Futuna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'WF'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Nouvelle-Zélande',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Neuseeland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Nueva Zelanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Nuova Zelanda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Uusi-Seelanti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'New Zealand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'New Zealand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nya Zeeland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'New Zealand',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'新西兰',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Nowa Zelandia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'뉴질랜드',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nový Zéland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ニュージーランド',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nieuw-Zeeland',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Nova Zelândia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Curazao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'库拉索',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'퀴라소',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'キュラソー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Curaçao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Curaçau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CW'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'加纳',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'가나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ガーナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Ghana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Gana',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'GH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Chypre',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Zypern',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Chipre',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Cipro',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kypros',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kypros',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kypros',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Cypern',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Cypern',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'塞浦路斯',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Cypr',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'키프로스',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kypr',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'キプロス',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Cyprus',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Chipre',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'CY'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Éthiopie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Äthiopien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Etiopía',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Etiopia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Etiopia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Etiopia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Etiopia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Etiopien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Etiopien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'埃塞俄比亚',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Etiopia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'에티오피아',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Etiopie',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'エチオピア',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Ethiopië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Etiópia',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'ET'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'R.A.S. chinoise de Macao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Sonderverwaltungsregion Macau',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'RAE de Macao (China)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'RAS di Macao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Macao – Kiinan e.h.a.',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Macao S.A.R. Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Macao S.A.R. Kina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Macao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'SAR Macao',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'中国澳门特别行政区',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'SRA Makau (Chiny)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'마카오(중국 특별행정구)',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Macao – ZAO Číny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'中華人民共和国マカオ特別行政区',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Macau SAR van China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Macau, RAE da China',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MO'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Îles Marshall',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Marshallinseln',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Islas Marshall',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Isole Marshall',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Marshallinsaaret',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Marshalløyane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Marshalløyene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Marshallöarna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Marshalløerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马绍尔群岛',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspy Marshalla',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'마셜 제도',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Marshallovy ostrovy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マーシャル諸島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Marshalleilanden',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Ilhas Marshall',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Antarctique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Antártida',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Antartide',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Antarktis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'南极洲',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Antarktyda',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'남극 대륙',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Antarktida',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'南極',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Antarctica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Antártida',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Sainte-Hélène',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Santa Elena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Sant’Elena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Saint Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'St. Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'S:t Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'St. Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣赫勒拿',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Wyspa Świętej Heleny',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세인트헬레나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatá Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セントヘレナ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Sint-Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Santa Helena',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SH'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Svalbard et Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Spitzbergen und Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Svalbard y Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Svalbard e Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Huippuvuoret ja Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Svalbard og Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Svalbard og Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Svalbard och Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Svalbard og Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'斯瓦尔巴和扬马延',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Svalbard i Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'스발바르제도-얀마웬섬',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Špicberky a Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'スバールバル諸島・ヤンマイエン島',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Spitsbergen en Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Svalbard e Jan Mayen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SJ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Dominique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'多米尼克',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Dominika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'도미니카',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Dominika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ドミニカ国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Dominica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Domínica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'DM'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'États-Unis',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Vereinigte Staaten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Estados Unidos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Stati Uniti',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Yhdysvallat',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'USA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'USA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'USA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'USA',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'美国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Stany Zjednoczone',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'미국',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Spojené státy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アメリカ合衆国',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Verenigde Staten',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Estados Unidos',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'US'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Argentine',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Argentinien',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Argentiina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'阿根廷',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Argentyna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'아르헨티나',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'アルゼンチン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Argentinië',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Argentina',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'AR'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Luxembourg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Luxemburg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Luxemburgo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Lussemburgo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Luxemburg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Luxembourg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Luxemburg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Luxemburg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Luxembourg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'卢森堡',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Luksemburg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'룩셈부르크',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Lucembursko',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ルクセンブルク',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Luxemburg',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Luxemburgo',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'LU'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Martinica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Martinica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'马提尼克',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Martynika',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'마르티니크',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Martinik',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'マルティニーク',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Martinique',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Martinica',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MQ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Seychelles',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Seychellen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Seychelles',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Seychelles',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Seychellit',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Seychellane',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Seychellene',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Seychellerna',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Seychellerne',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'塞舌尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Seszele',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'세이셸',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Seychely',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'セーシェル',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Seychellen',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Seicheles',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'SC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Mónaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'摩纳哥',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Monako',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'모나코',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Monako',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'モナコ',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Monaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Mónaco',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'MC'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Kazakhstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Kasachstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Kazajistán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Kazakistan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Kazakstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Kasakhstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Kasakhstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Kazakstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Kasakhstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'哈萨克斯坦',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Kazachstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'카자흐스탄',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Kazachstán',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'カザフスタン',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Kazachstan',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Cazaquistão',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'KZ'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Népal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'尼泊尔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'네팔',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Nepál',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'ネパール',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'Nepal',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'NP'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fr-fr',
    N'Saint-Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'de-de',
    N'St. Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'es-es',
    N'San Bartolomé',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'it-it',
    N'Saint-Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'fi',
    N'Saint-Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nn-no',
    N'Saint Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nb-no',
    N'Saint-Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'sv-se',
    N'S:t Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'da-dk',
    N'Saint Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'zh',
    N'圣巴泰勒米',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pl-pl',
    N'Saint-Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ko',
    N'생바르텔레미',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'cs-cz',
    N'Svatý Bartoloměj',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'ja-jp',
    N'サン・バルテルミー',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'nl-nl',
    N'Saint-Barthélemy',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

INSERT INTO #CountryTranslationTemp ([CountryId], [BCP47LanguageTagCode], [LocalisedCountryName], [ActiveStatus])
SELECT
    c.[CountryId],
    'pt-pt',
    N'São Bartolomeu',
    1
FROM [dbo].[Country] C
WHERE c.[ISO31661A2CountryCode] = 'BL'

MERGE INTO [dbo].[CountryTranslation] AS target
USING #CountryTranslationTemp AS source
ON target.[CountryId] = source.[CountryId]
AND target.[BCP47LanguageTagCode] = source.[BCP47LanguageTagCode]
WHEN NOT MATCHED THEN
INSERT 
(
    [CountryId],
    [BCP47LanguageTagCode],
    [LocalisedCountryName],
    [ActiveStatus]
)
VALUES 
(
    source.[CountryId],
    source.[BCP47LanguageTagCode],
    source.[LocalisedCountryName],
    source.[ActiveStatus]
);

DROP TABLE #CountryTranslationTemp