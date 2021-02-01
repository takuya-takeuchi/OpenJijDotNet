#ifndef _CPP_STD_VECTOR_H_
#define _CPP_STD_VECTOR_H_

#include "../export.h"
#include "../shared.h"

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__>;\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new3(__TYPE__* data, size_t dataLength)\
{\
    return new std::vector<__TYPE__>(data, data + dataLength);\
}\
\
DLLEXPORT size_t std_vector_##__TYPENAME__##_getSize(std::vector<__TYPE__>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_getPointer(std::vector<__TYPE__> *vector)\
{\
    return &(vector->at(0));\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_delete(std::vector<__TYPE__> *vector)\
{\
    delete vector;\
}\

#pragma endregion template

// primitives
MAKE_FUNC(int32_t, int32)
MAKE_FUNC(uint64_t, ulong)

#endif