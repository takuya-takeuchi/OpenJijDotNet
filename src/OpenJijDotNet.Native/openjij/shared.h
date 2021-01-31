#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

#include <regex>

enum struct array2d_type : int
{
    UInt8 = 0,
    UInt16,
    UInt32,
    Int8,
    Int16,
    Int32,
    Float,
    Double,
    RgbPixel,
    BgrPixel,
    RgbAlphaPixel,
    HsiPixel,
    LabPixel,
    Matrix
};

#endif