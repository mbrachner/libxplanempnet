cmake_minimum_required(VERSION 3.12)

include(FetchContent)

FetchContent_Declare(
  libxplanemp
  GIT_REPOSITORY https://github.com/kuroneko/libxplanemp.git
)

FetchContent_Declare(
  vcpkg
  GIT_REPOSITORY https://github.com/Microsoft/vcpkg.git
)

FetchContent_Declare(
  xpsdk
  URL http://developer.x-plane.com/wp-content/plugins/code-sample-generation/sample_templates/XPSDK301.zip
)

FetchContent_GetProperties(vcpkg)
if (NOT vcpkg_POPULATED)
  FetchContent_Populate(vcpkg)
  set(CMAKE_TOOLCHAIN_FILE ${vcpkg_SOURCE_DIR/scripts/buildsystems/vcpkg.cmake})
endif()



FetchContent_GetProperties(xpsdk)
if (NOT xpsdk_POPULATED)
  FetchContent_Populate(xpsdk)
  set(XPSDK_DIR ${xpsdk_SOURCE_DIR})
endif()
#find_library(ZLIB REQUIRED)
#find_package(PNG REQUIRED)
#target_link_libraries(xplanemp PRIVATE PNG::PNG)

FetchContent_GetProperties(libxplanemp)
if(NOT libxplanemp_POPULATED)
  FetchContent_Populate(libxplanemp)
  add_subdirectory(${libxplanemp_SOURCE_DIR} ${libxplanemp_BINARY_DIR})
endif()

#cmake -DCMAKE_INCLUDE_PATH=C:\Users\markusb\Source\Repos\libxplanempnew\XPSDK301\SDK\ -DCMAKE_TOOLCHAIN_FILE=C:\Users\markusb\Source\Repos\libxplanempnew\vcpkg\scripts\buildsystems\vcpkg.cmake -G "Visual Studio 15 Win64" -DCMAKE_CXX_FLAGS=/I"C:\Users\markusb\Source\Repos\libxplanempnew\vcpkg\installed\x64-windows\include" .
