export interface PredictionResponse {
    Prediction: number;
    Explanation: {
        MeanPrice: number;
        Suburb: number;
        Rooms: number;
        Type: number;
        Price: number;
        Method: number;
        PostCode: number;
        RegionName: number;
        PropertyCount: number;
        Distance: number;
        CouncilArea: number;
    };
}
