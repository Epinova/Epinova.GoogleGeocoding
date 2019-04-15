namespace Epinova.GoogleGeocodingTests
{
    partial class GeocodingServiceTests
    {
        private static string GetValidPostalCodeResult()
        {
            return @"{
   ""results"" : [
            {
                ""address_components"" : [
                {
                    ""long_name"" : ""0672"",
                    ""short_name"" : ""0672"",
                    ""types"" : [ ""postal_code"" ]
                },
                {
                    ""long_name"" : ""Oslo"",
                    ""short_name"" : ""Oslo"",
                    ""types"" : [ ""postal_town"" ]
                },
                {
                    ""long_name"" : ""Oslo kommune"",
                    ""short_name"" : ""Oslo kommune"",
                    ""types"" : [ ""administrative_area_level_2"", ""political"" ]
                },
                {
                    ""long_name"" : ""Oslo"",
                    ""short_name"" : ""Oslo"",
                    ""types"" : [ ""administrative_area_level_1"", ""political"" ]
                },
                {
                    ""long_name"" : ""Norge"",
                    ""short_name"" : ""NO"",
                    ""types"" : [ ""country"", ""political"" ]
                }
                ],
                ""formatted_address"" : ""0672 Oslo, Norge"",
                ""geometry"" : {
                    ""bounds"" : {
                        ""northeast"" : {
                            ""lat"" : 59.9180594,
                            ""lng"" : 10.8781187
                        },
                        ""southwest"" : {
                            ""lat"" : 59.90283059999999,
                            ""lng"" : 10.8472589
                        }
                    },
                    ""location"" : {
                        ""lat"" : 59.9101185,
                        ""lng"" : 10.8608624
                    },
                    ""location_type"" : ""APPROXIMATE"",
                    ""viewport"" : {
                        ""northeast"" : {
                            ""lat"" : 59.9180594,
                            ""lng"" : 10.8781187
                        },
                        ""southwest"" : {
                            ""lat"" : 59.90283059999999,
                            ""lng"" : 10.8472589
                        }
                    }
                },
                ""place_id"" : ""ChIJB-WEVoFvQUYRdxXUTSu_Q8g"",
                ""types"" : [ ""postal_code"" ]
            }
            ],
            ""status"" : ""OK""
        }
        ";
        }

        public static string GetInvaldResult()
        {
            return @"{
   ""error_message"" : ""This API project is not authorized to use this API."",
   ""results"" : [],
   ""status"" : ""REQUEST_DENIED""
}
";
        }
    }
}