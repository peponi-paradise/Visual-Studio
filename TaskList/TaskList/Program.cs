using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             작업 목록에 등록되는 주석 구분
            1. 주석 마커 : //
            2. 토큰 : TODO, HACK, ...)
            3. 주석 내용
             */

            // C/C++, C#, Visual Basic용 기본 토큰 예시

            // TODO: 작업 목록 1
            // HACK: 작업 목록 2
            // UNDONE: 작업 목록 3
            // UnresolvedMergeConflict: 작업 목록 4

            // 사용자 정의 토큰 예시

            // UserAdded: 작업 목록 5
            // UserAdded2: 작업 목록 6
            // UserAdded3: 작업 목록 7
        }
    }
}