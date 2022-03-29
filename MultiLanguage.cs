using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition
{
    public class MultiLanguage
    {
        public static string[][] en = new string[][]
        {
            new string[] {"ServerStatusError","Can't connect to server" },
            new string[] {"App Name","Face Recognition"},
            new string[] {"frmSetting","System configuration"},
            new string[] {"DeviceTreeViewName","Devices"},

            new string[] {"changeLanguage_message","Change language success, restart app to apply change"},
            new string[] {"RestartRequest","Restart app to apply change"},

            new string[] { "login_option", "Option" },
            new string[] { "login_message", "Program login in {0} seconds"},
            new string[] { "access_admin", "admin" },
            new string[] { "access_user", "user"},
            //frmCamera
            new string[] {"frmCameraAdd","Add Camera"},
            new string[] {"frmCameraEdit","Edit Camera"},
            new string[] {"DeleteTittleCamera","Delete Camera"},

            new string[] {"CameraNameEmpty","Camera Name isn't allowed emplty"},
            new string[] {"CameraCodeEmpty","Camera Code isn't allowed emplty"},
            new string[] {"CameraTypeEmpty","Camera Type isn't allowed emplty"},
            new string[] {"CameraIPEmpty","Camera IP isn't allowed emplty"},
            new string[] {"CameraPortEmpty","Camera Port isn't allowed emplty"},
            new string[] {"CameraUsernameEmpty","Camera Username isn't allowed emplty"},
            new string[] {"CameraPasswordEmpty","Camera Password isn't allowed emplty"},
            new string[] {"CameraComEmpty","Camera Com isn't allowed emplty"},
            new string[] {"CameraChannelEmpty","Camera Channel isn't allowed emplty"},

            new string[] {"CameraEditError","Edit Camera Error"},
            new string[] {"CameraAddError","Add Camera Error"},
            new string[] {"CameraDeleteError","Delete Camera Error"},

            new string[] {"RecordSelectRequest","Please select a record"},
            //frmGroupFace
            new string[] {"frmGroupFaceAdd","Add Group Face"},
            new string[] {"frmGroupFaceEdit","Edit Group Face"},

            new string[] {"GroupNameEmpty","Group Name isn't allowed emplty"},
            new string[] {"GroupDescriptionEmpty","Group Description isn't allowed emplty"},

            new string[] { "GroupEditError", "Edit Group Error"},
            new string[] { "GroupAddError", "Add Group Error"},
            new string[] { "GroupDeleteError", "Delete Group Error"},

            new string[] {"RecordSelectRequest","Please select a record"},
            //frmFacePerson
            new string[] {"frmPersonFaceAdd","Add Person Face"},
            new string[] { "frmPersonFaceEdit", "Edit Person Face"},
            new string[] {"DeleteTittleFacePerson","Delete Person face"},

            new string[] { "PersonFaceNameEmpty", "PersonFace Name isn't allowed emplty"},
            new string[] { "PersonFaceGroupIDEmpty", "PersonFace GroupID isn't allowed emplty"},
            new string[] { "PersonFacePositionEmpty", "PersonFace Position isn't allowed emplty"},
            new string[] { "PersonFaceSexEmpty", "PersonFace Sex isn't allowed emplty"},
            new string[] { "PersonFaceImageEmpty", "PersonFace Image isn't allowed emplty"},
            new string[] { "PersonFaceCardTypeEmpty", "PersonFace CardType isn't allowed emplty"},
            new string[] { "PersonFaceCardIDEmpty", "PersonFace CardID isn't allowed emplty"},

            new string[] { "PersonFaceEditError", "Edit Person Face Error"},
            new string[] { "PersonFaceAddError", "Add Person Face Error"},
            new string[] { "PersonFaceDeleteError", "Delete Person Face Error"},

            new string[] {"RecordSelectRequest","Please select a record"},
            //frmUser
            new string[] {"frmUserAdd","Add User"},
            new string[] { "frmUserEdit", "Edit user"},

            new string[] { "AccessAdmin", "Administrator"},
            new string[] { "AccessUser", "User"},

            new string[] { "UsercodeEmpty", "Usercode isn't allowed emplty"},
            new string[] { "FullnameEmpty", "Fullname isn't allowed emplty"},
            new string[] { "UsernameEmpty", "Username isn't allowed emplty"},
            new string[] { "PasswordEmpty", "Password isn't allowed emplty"},
            new string[] { "RetypePasswordError", "Retype Password isn't same as Password"},
            new string[] { "AccessEmpty", "Access isn't allowed emplty"},

            new string[] { "UserEditError", "Edit Person Face Error"},
            new string[] { "UserAddError", "Add Person Face Error"},
            new string[] { "UserDeleteError", "Delete Person Face Error"},

            new string[] {"RecordSelectRequest","Please select a record"},
            new string[] { "SexUnlimited", "Unlimited"},
            new string[] { "SexMale", "Male"},
            new string[] { "SexFemale", "Female"},
            //frm system report
            new string[] {"frmSystemReport","System Report"},
            //frm Select Databaase
            new string[] { "frmSelectDatabase", "Select Database"},
            //Position
            new string[] { "Position1", "Hardware"},
            new string[] { "Position2", "Sofeware"},
            new string[] { "Position3", "Sale"},
            //CardType
            new string[] { "CardTypeIC", "IC"},
            new string[] { "CardTypePassport", "Passport"},
            new string[] { "CardTypeMilitary", "Military"},
            new string[] { "CardTypeUnknown", "Unknown"},
            //General
            new string[] { "GroupCreateRequest", "Please create a group first"},
            new string[] { "LoginError", "login unsuccess"},
            new string[] { "StartLiveviewError", "Login Success, StartLiveview unsuccess"},
            new string[] { "LogoutError", "Logout unsuccess"},
            new string[] { "StopLiveviewError", "Stop liveview unsuccess"},
            new string[] { "LiveviewRequest", "Please start liveview first"},
            new string[] { "TakePictureRequest", "You dont select any pictures!"},
            //Event
            new string[] { "Sex0", "Man"},
            new string[] { "Sex1", "Woman"},
            new string[] { "Sex2", "Unknown"},
            new string[] { "PersonMask0", "Not detected"},
            new string[] { "PersonMask1", "Not wearing mask"},
            new string[] { "PersonMask2", "Wearing mask"},
            new string[] { "PersonBeard0", "Not detected"},
            new string[] { "PersonBeard1", "No Beard"},
            new string[] { "PersonBeard2", "Has Beard"},
            //
            new string[] { "SDKInitError", "SDK Init error"},
            new string[] { "LiveviewError", "Liveview error"},
            new string[] {"DeleteConfirm","Do you want to delete this record"},
        };

        public static string[][] vi = new string[][]
        {
            new string[] {"ServerStatusError","Không thể kết nối đến Server" },
            new string[] {"App Name","Nhận diện gương mặt"},
            new string[] {"frmSetting","Tham số hệ thống"},
            new string[] {"DeviceTreeViewName","Danh sách thiết bị"},

            new string[] {"changeLanguage_message","Thay đổi ngôn ngữ thành công, khởi động lại ứng dụng để cập nhật thay đổi"},
            new string[] {"RestartRequest","Khởi động lại ứng dụng để cập nhật thay đổi"},

            new string[] { "login_option", "Tùy chọn" },
            new string[] { "login_message", "Đăng nhập sau {0} giây"},
            new string[] { "access_admin", "Quản lý hệ thống" },
            new string[] { "access_user", "Nguời dùng"},

            //frmCamera
            new string[] {"frmCameraAdd","Thêm Camera"},
            new string[] {"frmCameraEdit","Sửa Camera"},
            new string[] {"DeleteTittleCamera","Xóa Camera"},

            new string[] {"CameraNameEmpty","Tên Camera không được để trống"},
            new string[] {"CameraCodeEmpty","Mã Camera không được để trống"},
            new string[] {"CameraTypeEmpty","Loại Camera không được để trống"},
            new string[] {"CameraIPEmpty","IP Camera không được để trống"},
            new string[] {"CameraPortEmpty","Cổng Camera không được để trống"},
            new string[] {"CameraUsernameEmpty","Tên đăng nhập Camera không được để trốngy"},
            new string[] {"CameraPasswordEmpty","Mật khẩu Camera không được để trống"},
            new string[] {"CameraComEmpty","Com kết nối Camera không được để trống"},
            new string[] {"CameraChannelEmpty","Kênh kết nối Camera không được để trống"},

            new string[] {"CameraEditError","Sửa Camera không thành công"},
            new string[] {"CameraAddError","Thêm Camera không thành công"},
            new string[] {"CameraDeleteError","Xóa Camera Không thành công"},

            new string[] {"RecordSelectRequest","Làm ơn chọn một bản ghi"},
             //frmGroupFace
            new string[] {"frmGroupFaceAdd","Thêm nhóm"},
            new string[] {"frmGroupFaceEdit","Sửa nhóm"},

            new string[] {"GroupNameEmpty","Tên nhóm không được để trống"},
            new string[] {"GroupDescriptionEmpty","Mô tả nhóm không được để trống"},

            new string[] { "GroupEditError", "Sửa nhóm không thành côngr"},
            new string[] { "GroupAddError", "Thêm nhóm không thành công"},
            new string[] { "GroupDeleteError", "Xóa nhóm Không thành công"},

            new string[] {"RecordSelectRequest","Làm ơn chọn một bản ghi"},
             //frmFacePerson
            new string[] {"frmPersonFaceAdd","Thêm Person Face"},
            new string[] { "frmPersonFaceEdit", "Sửa Person Face"},
            new string[] {"DeleteTittleFacePerson","Xóa Gương Mặt"},

            new string[] { "PersonFaceNameEmpty", "Tên không được để trống"},
            new string[] { "PersonFaceGroupIDEmpty", "Mã số nhóm không được để trống"},
            new string[] { "PersonFacePositionEmpty", "Chức vụ không được để trống"},
            new string[] { "PersonFaceSexEmpty", "Giới tính không được để trống"},
            new string[] { "PersonFaceImageEmpty", "Hình ảnh không được để trống"},
            new string[] { "PersonFaceCardTypeEmpty", "Loại thẻ không được để trống"},
            new string[] { "PersonFaceCardIDEmpty", "Mã số thẻ không được để trống"},

            new string[] { "PersonFaceEditError", "Edit Person Face Error"},
            new string[] { "PersonFaceAddError", "Add Person Face Error"},
            new string[] { "PersonFaceDeleteError", "Delete Person Face Error"},

            new string[] {"RecordSelectRequest","Please select a record"},
            //frmUser
            new string[] {"frmUserAdd","Thêm người dùng"},
            new string[] { "frmUserEdit", "Sửa người dùng"},

            new string[] { "AccessAdmin", "Quản trị hệ thống"},
            new string[] { "AccessUser", "Người dùng"},
             new string[] { "UsercodeEmpty", "Mã người dùng không được để trống"},
            new string[] { "FullnameEmpty", "Họ tên không được để trống"},
            new string[] { "UsernameEmpty", "Tên đăng nhập không được để trống"},
            new string[] { "PasswordEmpty", "Mật khẩu không được để trống"},
            new string[] { "RetypePasswordError", "Hai mật khẩu không giống nhau"},
            new string[] { "AccessEmpty", "Quyền truy cập không được để trống"},

            new string[] { "UserEditError", "Sửa người dùng không thành công"},
            new string[] { "UserAddError", "Thêm người dùng không thành công"},
            new string[] { "UserDeleteError", "Xóa người dùng không thành công"},

            new string[] {"RecordSelectRequest","Làm ơn chọn một bản ghi"},            
            //frm system report
            new string[] {"frmSystemReport","Báo cáo hệ thống"},
            //frm Select Databaase
            new string[] {"frmSelectDatabase","Chọn cơ sở dữ liệu"},

            //Sex
            new string[] { "SexUnlimited", "Không xác định"},
            new string[] { "SexMale", "Nam"},
            new string[] { "SexFemale", "Nữ"},
            //Position
            new string[] { "Position1", "Phần cứng"},
            new string[] { "Position2", "Phần mềm"},
            new string[] { "Position3", "Kinh doanh"},
            //CardType
            new string[] { "CardTypeIC", "IC"},
            new string[] { "CardTypePassport", "Passport"},
            new string[] { "CardTypeMilitary", "Quân đội"},
            new string[] { "CardTypeUnknown", "Không xác định"},
            //General
            new string[] { "GroupCreateRequest", "Hãy tạo một nhóm trước"},
            new string[] { "LoginError", "Đăng nhập thất bại"},
            new string[] { "StartLiveviewError", "Đăng nhập thành công, xem trực tiếp thất bại"},
            new string[] { "LogoutError", "Đăng xuất thất bại"},
            new string[] { "StopLiveviewError", "Ngừng xem trực tiếp thất bại"},
            new string[] { "LiveviewRequest", "Hãy chọn 1 camera xem trực tiếp trước"},
            new string[] { "TakePictureRequest", "Bạn chưa chọn hình ảnh nào!"},
            //Event
            new string[] { "Sex0", "Nam"},
            new string[] { "Sex1", "Nữ"},
            new string[] { "Sex2", "Không xác định"},
            new string[] { "PersonMask0", "Không xác định"},
            new string[] { "PersonMask1", "Không đeo khẩu trang"},
            new string[] { "PersonMask2", "Đeo khẩu trang"},
            new string[] { "PersonBeard0", "Không xác định"},
            new string[] { "PersonBeard1", "Không có râu"},
            new string[] { "PersonBeard2", "có râu"},
            //
            new string[] { "SDKInitError", "Khởi tạo SDK không thành công"},
            new string[] { "LiveviewError", "xem trực tiếp không thành công"},
            new string[] {"DeleteConfirm","Bạn có muốn xóa bản ghi này"},
        };

        public static string GetString(string stringname, string culture = "")
        {
            if (culture == "")
                culture = StaticPool.Language;
            if (culture == "en")
            {
                var result = en.Where(n => n[0] == stringname).FirstOrDefault();
                if (result != null)
                    return result[1];
            }
            else if (culture == "vi" || culture == "vi-VN")
            {
                var result = vi.Where(n => n[0] == stringname).FirstOrDefault();
                if (result != null)
                    return result[1];
            }
            return "";
        }
    }
}